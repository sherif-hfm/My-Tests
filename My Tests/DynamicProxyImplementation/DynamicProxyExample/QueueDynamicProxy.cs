using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicProxyImplementation;

namespace DynamicProxyExample
{
    public class QueueDynamicProxy : DynamicProxy
    {
        private enum ActionType { Invoke, Set, Event }
        private object realImplementation = null;
        private Queue<Tuple<ActionType, Type, string, object>> queue = new Queue<Tuple<ActionType, Type, string, object>>();
        private Type interfaceType;
        public QueueDynamicProxy(Type interfaceType)
        {
            this.interfaceType = interfaceType;

            if (TestDIContainer.HasRealImplementation(interfaceType))
            {
                if (realImplementation == null)
                {
                    realImplementation = TestDIContainer.GetInstance(interfaceType);
                }
            }
            else
            {
                TestDIContainer.NewTypeRegistered += TestDIContainer_NewTypeRegistered;
            }
        }

        private void TestDIContainer_NewTypeRegistered(object sender, EventArgs e)
        {
            TestDIContainer.NewTypeRegistered -= TestDIContainer_NewTypeRegistered;

            if (TestDIContainer.HasRealImplementation(interfaceType))
            {
                realImplementation = TestDIContainer.GetInstance(interfaceType);

                foreach (var invocation in queue)
                {
                    if (invocation.Item1 == ActionType.Invoke)
                    {
                        var mi = TypeHelper.GetMethodInfo(realImplementation.GetType(), invocation.Item3, (object[])invocation.Item4);
                        mi.Invoke(realImplementation, (object[])invocation.Item4);
                    }
                    else if (invocation.Item1 == ActionType.Set)
                    {
                        var pi = TypeHelper.GetPropertyInfo(realImplementation.GetType(), null, invocation.Item3);
                        pi.SetValue(realImplementation, invocation.Item4);
                    }
                    else if (invocation.Item1 == ActionType.Event)
                    {
                        var ei = TypeHelper.GetEventInfo(realImplementation.GetType(), invocation.Item3);
                        ei.AddEventHandler(realImplementation, (Delegate)invocation.Item4);
                    }
                }
            }
        }

        protected override bool TryInvokeMember(Type interfaceType, string name, object[] args, out object result)
        {
            if (interfaceType != this.interfaceType)
            {
                throw new ArgumentException();
            }

            if (realImplementation != null)
            {
                var mi = TypeHelper.GetMethodInfo(realImplementation.GetType(), name, args);
                result = mi.Invoke(realImplementation, args);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Method invocation queued. Interface type: {0}. Method name: {1}. Arguments: {2}.", interfaceType.Name, name, string.Join(",", args)));

                queue.Enqueue(new Tuple<ActionType, Type, string, object>(ActionType.Invoke, interfaceType, name, args));
                result = null;
            }
            return true;
        }

        protected override bool TrySetMember(Type interfaceType, string name, object value)
        {
            if (interfaceType != this.interfaceType)
            {
                throw new ArgumentException();
            }

            if (realImplementation != null)
            {
                var pi = TypeHelper.GetPropertyInfo(realImplementation.GetType(), null, name);
                pi.SetValue(realImplementation, value);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Set property. Interface type: {0}. Member name: {1}. Value: {2}.", interfaceType.Name, name, value));
                queue.Enqueue(new Tuple<ActionType, Type, string, object>(ActionType.Set, interfaceType, name, value));
            }
            return true;
        }

        protected override bool TryGetMember(Type interfaceType, string name, out object result)
        {
            if (interfaceType != this.interfaceType)
            {
                throw new ArgumentException();
            }

            if (realImplementation != null)
            {
                var pi = TypeHelper.GetPropertyInfo(realImplementation.GetType(), null, name);
                result = pi.GetValue(realImplementation);
            }
            else
            {
                throw new InvalidOperationException();
            }
            return true;
        }

        protected override bool TrySetEvent(Type interfaceType, string name, object value)
        {
            if (interfaceType != this.interfaceType)
            {
                throw new ArgumentException();
            }

            if (realImplementation != null)
            {
                var ei = TypeHelper.GetEventInfo(realImplementation.GetType(), name);
                ei.AddEventHandler(realImplementation, (Delegate)value);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Set event. Interface type: {0}. Member name: {1}. Value: {2}.", interfaceType.Name, name, value));
                queue.Enqueue(new Tuple<ActionType, Type, string, object>(ActionType.Event, interfaceType, name, value));
            }
            return true;
        }
    }
}
