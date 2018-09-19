using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicImplement
{
    public class DynamicInterfaceImplementor : IDynamicInterfaceImplementor
    {
        private string ownClassName = typeof(DynamicInterfaceImplementor).Name;
        private SpinLock dynamicTypeEmitSyncRoot = new SpinLock();
        private Dictionary<string, Type> dynamicTypes = new Dictionary<string, Type>();
        private ModuleBuilder moduleBuilder = null;
        private MethodInfo listAddMethodInfo = null;
        private MethodInfo listToArrayMethodInfo = null;
        private MethodInfo getTypeFromHandleMethodInfo = null;
        private MethodInfo delegateCombineMethodInfo = null;
        private MethodInfo delegateRemoveMethodInfo = null;
        private MethodInfo activatorCreateInstanceMethodInfo = null;

  
        private MethodInfo tryInvokeMemberInfo = null;

        private string listAddMethodName = ExpressionHelper.GetMethodCallExpressionMethodInfo<List<object>>(l => l.Add(new object())).Name;
        private string listToArrayMethodName = ExpressionHelper.GetMethodCallExpressionMethodInfo<List<object>>(l => l.ToArray()).Name;
        private string createInstanceMethodName = ExpressionHelper.GetMethodCallExpressionMethodInfo<object>(a => Activator.CreateInstance(a.GetType())).Name;
        private string delegateCombineMethodName = ExpressionHelper.GetMethodCallExpressionMethodInfo<Delegate>(d => Delegate.Combine(d, d)).Name;
        private string delegateRemoveMethodName = ExpressionHelper.GetMethodCallExpressionMethodInfo<Delegate>(d => Delegate.Remove(d, d)).Name;
        private string getTypeFromHandleMethodName = ExpressionHelper.GetMethodCallExpressionMethodInfo<RuntimeTypeHandle>(t => Type.GetTypeFromHandle(t)).Name;

        public DynamicInterfaceImplementor()
        {
            InitTypeBuilder();
        }

        private void InitTypeBuilder()
        {
          
            tryInvokeMemberInfo = DynamicProxy.TryInvokeMemberMethodInfo;

            Type ownClass = typeof(DynamicInterfaceImplementor);
            string guid = Guid.NewGuid().ToString();
            AssemblyName assemblyName = new AssemblyName(string.Concat(ownClass.Namespace, ".", ownClass.Name, "_", guid));

            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
            moduleBuilder = ab.DefineDynamicModule(assemblyName.Name, string.Concat(assemblyName.Name, ".dll"));

            listAddMethodInfo = TypeHelper.GetMethodInfo(typeof(List<object>), listAddMethodName, new Type[] { typeof(object) });
            listToArrayMethodInfo = TypeHelper.GetMethodInfo(typeof(List<object>), listToArrayMethodName, Type.EmptyTypes);

            getTypeFromHandleMethodInfo = TypeHelper.GetMethodInfo(typeof(Type), getTypeFromHandleMethodName, new Type[] { typeof(RuntimeTypeHandle) });
            delegateCombineMethodInfo = TypeHelper.GetMethodInfo(typeof(Delegate), delegateCombineMethodName, new Type[] { typeof(Delegate), typeof(Delegate) });
            delegateRemoveMethodInfo = TypeHelper.GetMethodInfo(typeof(Delegate), delegateRemoveMethodName, new Type[] { typeof(Delegate), typeof(Delegate) });
            activatorCreateInstanceMethodInfo = TypeHelper.GetMethodInfo(typeof(Activator), createInstanceMethodName, new Type[] { typeof(Type) });
                       
        }

        public virtual Type CreateType(Type interfaceType, Type dynamicProxyBaseType)
        {
            Type ret;
           
            string typeName = string.Concat(ownClassName, "+", interfaceType.FullName);
            bool gotLock = false;
            try
            {
                dynamicTypeEmitSyncRoot.Enter(ref gotLock);
                dynamicTypes.TryGetValue(typeName, out ret);

                if (ret == null)
                {
                    TypeBuilder tb = moduleBuilder.DefineType(typeName, TypeAttributes.Public);
                    tb.SetParent(dynamicProxyBaseType);
                    tb.AddInterfaceImplementation(interfaceType);

                    DynamicImplementInterface(new List<Type> { interfaceType }, new List<string>(), interfaceType, tb);
                                     
                    ret = tb.CreateType();

                    dynamicTypes.Add(typeName, ret);
                }
            }
            finally
            {
                if (gotLock)
                {
                    dynamicTypeEmitSyncRoot.Exit();
                }
            }

            return ret;
        }

        private void DynamicImplementInterface(List<Type> implementedInterfaceList, List<string> usedNames, Type interfaceType, TypeBuilder tb)
        {
            if (interfaceType != typeof(IDisposable))
            {
                List<MethodInfo> propAccessorList = new List<MethodInfo>();

                GenerateMethods(usedNames, interfaceType, tb, propAccessorList);

                foreach (Type i in interfaceType.GetInterfaces())
                {
                    if (!implementedInterfaceList.Contains(i))
                    {
                        DynamicImplementInterface(implementedInterfaceList, usedNames, i, tb);
                        implementedInterfaceList.Add(i);
                    }
                }
            }
        }

        private void GenerateMethods(List<string> usedNames, Type interfaceType, TypeBuilder tb, List<MethodInfo> propAccessors)
        {
            foreach (MethodInfo mi in interfaceType.GetMethods())
            {
                var parameterInfoArray = mi.GetParameters();
                var genericArgumentArray = mi.GetGenericArguments();

                string paramNames = string.Join(", ", parameterInfoArray.Select(pi => pi.ParameterType));
                string nameWithParams = string.Concat(mi.Name, "(", paramNames, ")");
                if (usedNames.Contains(nameWithParams))
                {
                    throw new NotSupportedException(string.Format("Error in interface {1}! Method '{0}' already used in other child interface!", nameWithParams, interfaceType.Name)); //LOCSTR
                }
                else
                {
                    usedNames.Add(nameWithParams);
                }

                if (!propAccessors.Contains(mi))
                {
                    MethodBuilder mb = tb.DefineMethod(mi.Name, MethodAttributes.Public | MethodAttributes.Virtual, mi.ReturnType, parameterInfoArray.Select(pi => pi.ParameterType).ToArray());
                    if (genericArgumentArray.Any())
                    {
                        mb.DefineGenericParameters(genericArgumentArray.Select(s => s.Name).ToArray());
                    }

                    EmitInvokeMethod(mi, mb);

                    tb.DefineMethodOverride(mb, mi);
                }
            }
        }

        private void EmitInvokeMethod(MethodInfo mi, MethodBuilder mb)
        {
            ILGenerator ilGenerator = mb.GetILGenerator();

            string methodName = mb.Name;
            LocalBuilder typeLb = ilGenerator.DeclareLocal(typeof(Type), true);
            LocalBuilder paramsLb = ilGenerator.DeclareLocal(typeof(List<object>), true);
            LocalBuilder resultLb = ilGenerator.DeclareLocal(typeof(object), true);
            LocalBuilder retLb = ilGenerator.DeclareLocal(typeof(bool), true);

            //C#: Type.GetTypeFromHandle(interfaceType)
            EmitAndStoreGetTypeFromHandle(ilGenerator, mi.DeclaringType, OpCodes.Stloc_0);

            //C#: params = new List<object>()
            ilGenerator.Emit(OpCodes.Newobj, typeof(List<object>).GetConstructor(Type.EmptyTypes));
            ilGenerator.Emit(OpCodes.Stloc_1);

            int i = 0;
            foreach (ParameterInfo pi in mi.GetParameters())
            {
                //C#: params.Add(param[i])
                i++;
                ilGenerator.Emit(OpCodes.Ldloc_1);
                ilGenerator.Emit(OpCodes.Ldarg, i);
                if (pi.ParameterType.IsValueType)
                {
                    ilGenerator.Emit(OpCodes.Box, pi.ParameterType);
                }
                //ilGenerator.EmitCall(OpCodes.Callvirt, listAddMethodInfo, null);
            }
            //C#: ret = DynamicProxy.TryInvokeMember(interfaceType, propertyName, params, out result)
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldloc_0);
            ilGenerator.Emit(OpCodes.Ldstr, methodName);
            ilGenerator.Emit(OpCodes.Ldloc_1);
            //ilGenerator.EmitCall(OpCodes.Callvirt, listToArrayMethodInfo, null);
            ilGenerator.Emit(OpCodes.Ldloca_S, 2);
            ilGenerator.EmitCall(OpCodes.Callvirt, tryInvokeMemberInfo, null);
            ilGenerator.Emit(OpCodes.Stloc_3);

            if (mi.ReturnType != typeof(void))
            {
                ilGenerator.Emit(OpCodes.Ldloc_2);
                //C#: if(ret == ValueType && ret == null){
                //    ret = Activator.CreateInstance(returnType) }
                if (mi.ReturnType.IsValueType)
                {
                    Label retisnull = ilGenerator.DefineLabel();
                    Label endofif = ilGenerator.DefineLabel();

                    ilGenerator.Emit(OpCodes.Ldnull);
                    ilGenerator.Emit(OpCodes.Ceq);
                    ilGenerator.Emit(OpCodes.Brtrue_S, retisnull);
                    ilGenerator.Emit(OpCodes.Ldloc_2);
                    ilGenerator.Emit(OpCodes.Unbox_Any, mi.ReturnType);
                    ilGenerator.Emit(OpCodes.Br_S, endofif);
                    ilGenerator.MarkLabel(retisnull);
                    ilGenerator.Emit(OpCodes.Ldtoken, mi.ReturnType);
                    //ilGenerator.EmitCall(OpCodes.Call, getTypeFromHandleMethodInfo, null);
                    //ilGenerator.EmitCall(OpCodes.Call, activatorCreateInstanceMethodInfo, null);
                    ilGenerator.Emit(OpCodes.Unbox_Any, mi.ReturnType);
                    ilGenerator.MarkLabel(endofif);
                }
            }
            //C#: return ret
            ilGenerator.Emit(OpCodes.Ret);
        }

        private void EmitAndStoreGetTypeFromHandle(ILGenerator ilGenerator, Type type, OpCode storeCode)
        {
            //C#: Type.GetTypeFromHandle(interfaceType)
            ilGenerator.Emit(OpCodes.Ldtoken, type);
            ilGenerator.EmitCall(OpCodes.Call, getTypeFromHandleMethodInfo, null);
            ilGenerator.Emit(storeCode);
        }
    }
}
