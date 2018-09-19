using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Reflection;
namespace CallOracleStoredProcedure
{
    public class DbHelper 
    {
        private string cnnStr;
        public DbHelper(string _cnnStr)
        {
            cnnStr = _cnnStr;
        }

        public Dictionary<string, object> ExecuteNonQuery<T>(string _sqlStr, T _data, string _parametersMapperTemplate)
        {
            Dictionary<string, OracleParameter> dbPrmList = FillParameterValues<T>(_sqlStr, _data, _parametersMapperTemplate);
            ExecuteNonQuery(_sqlStr, dbPrmList);
            var oraPrmArray = (from p in dbPrmList select p.Value).ToArray<OracleParameter>();
            return GetOutParameters(oraPrmArray);
        }

        public Dictionary<string,object> ExecuteNonQuery(string _sqlStr, object _data)
        {
            Dictionary<string, OracleParameter> dbPrmList = FillParameterValues(_sqlStr, _data);
            ExecuteNonQuery(_sqlStr, dbPrmList);
            var oraPrmArray = (from p in dbPrmList select p.Value).ToArray<OracleParameter>();
            return GetOutParameters(oraPrmArray);
        }

        public DataTable ExecuteReader(string _sqlStr, Object _prms)
        {
            Dictionary<string, OracleParameter> dbPrmList = FillParameterValues(_sqlStr, _prms);
            return ExecuteReader(_sqlStr, dbPrmList);
        }

        public DataTable ExecuteReader<T>(string _sqlStr, T _data, string _parametersMapperTemplate)
        {
            Dictionary<string, OracleParameter> dbPrmList = FillParameterValues<T>(_sqlStr, _data, _parametersMapperTemplate);
            return ExecuteReader(_sqlStr, dbPrmList);
        }

        public List<Y> ExecuteReader<Y>(string _sqlStr, Object _prms, string _filedMapperTemplates)
        {
            DataTable resultTab = ExecuteReader(_sqlStr, _prms);
            return GetResultList<Y>(resultTab, _filedMapperTemplates);
        }

        public List<Y> ExecuteReader<T, Y>(string _sqlStr, T _data, string _parametersMapperTemplate, string _fieldsMapperTemplates)
        {
            DataTable resultTab = ExecuteReader(_sqlStr, _data, _parametersMapperTemplate);
            return GetResultList<Y>(resultTab, _fieldsMapperTemplates);
        }

        #region ***************** Private Methods *****************

        private List<Y> GetResultList<Y>(DataTable resultTab, string _mapperTemplate)
        {
            List<Y> list = new List<Y>();
            List<DataFieldPropertyInfo> propList = new List<DataFieldPropertyInfo>();         
            var colList= resultTab.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList<string>();
            FillPropertiesList<Y>(propList, _mapperTemplate);
            foreach (DataRow row in resultTab.Rows)
            {
                var item = DataRowToListItem<Y>(row, propList, colList);
                list.Add(item);
            }
            return list;
        }

        private Y DataRowToListItem<Y>(DataRow _row, List<DataFieldPropertyInfo> _propList, List<string> _colList)
        {
            var item = (Y)Activator.CreateInstance(typeof(Y));
            foreach (var prop in _propList)
            {
                if (prop.NestedProperties == null)
                {
                    if (_colList.Contains(prop.FieldName))
                    {
                        var colValueObj = _row.Field<object>(prop.FieldName);
                        var colValue = Convert.ChangeType(colValueObj, prop.PropertyInfo.PropertyType);
                        prop.PropertyInfo.SetValue(item, colValue);
                    }
                }
                else
                {
                    MethodInfo method = GetType().GetMethod("DataRowToListItem", BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(new Type[] { prop.PropertyInfo.PropertyType });
                    var nestedValue = method.Invoke(this, new object[] { _row, prop.NestedProperties, _colList });
                    prop.PropertyInfo.SetValue(item, nestedValue);
                }
                
            }
            return item;
        }

        private void FillPropertiesList<Y>(List<DataFieldPropertyInfo> _propList, string _mapperTemplate)
        {
            foreach (var propInfp in typeof(Y).GetProperties())
            {
                foreach (var attr in propInfp.CustomAttributes)
                {
                    var prm = GetDataFieldCustomAttribute(attr);
                    if (prm != null)
                    {
                        if (TemplatesContain(prm.MapperTemplates , _mapperTemplate))
                        {
                            if (prm.IsContainer == false)
                            {
                                _propList.Add(new DataFieldPropertyInfo() { FieldName = prm.FieldName, PropertyInfo = propInfp });
                            }
                            else
                            {
                                Type propType = propInfp.PropertyType;
                                List<DataFieldPropertyInfo> _nestedPropList = new List<DataFieldPropertyInfo>();
                                _propList.Add(new DataFieldPropertyInfo() { FieldName = "", PropertyInfo = propInfp, NestedProperties = _nestedPropList });
                                
                                MethodInfo method = GetType().GetMethod("FillPropertiesList", BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(new Type[] { propType });
                                method.Invoke(this, new object[] { _nestedPropList, _mapperTemplate });
                            }
                        }
                    }
                }
            }
        }

        private DataTable ExecuteReader(string _sqlStr,Dictionary<string, OracleParameter> dbPrmList)
        {
            DataTable result = new DataTable();
            OracleConnection cnn = new OracleConnection(cnnStr);
            OracleCommand cmd = new OracleCommand(_sqlStr, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            var oraPrmArray = (from p in dbPrmList select p.Value).ToArray<OracleParameter>();
            cmd.Parameters.AddRange(oraPrmArray);
            cnn.Open();
            using (OracleDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.HasRows)
                {
                    result.Load(rdr);
                }
            }
            cnn.Close();
            return result;
        }

        private void ExecuteNonQuery(string _sqlStr, Dictionary<string, OracleParameter> dbPrmList)
        {
            OracleConnection cnn = new OracleConnection(cnnStr);
            OracleCommand cmd = new OracleCommand(_sqlStr, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            var oraPrmArray = (from p in dbPrmList select p.Value).ToArray<OracleParameter>();
            cmd.Parameters.AddRange(oraPrmArray);
            cnn.Open();
            var result = cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private Dictionary<string, object> GetOutParameters(OracleParameter[] dbPrmList)
        {
            Dictionary<string, object> result =new  Dictionary<string, object>();
            foreach (var prm in dbPrmList)
            {
                if(prm.Direction == ParameterDirection.Output || prm.Direction == ParameterDirection.ReturnValue || prm.Direction == ParameterDirection.InputOutput)
                {
                    result.Add(prm.ParameterName, prm.Value);
                }
            }
            return result;
        }

        private Dictionary<string, OracleParameter> FillParameterValues(string _sqlStr, object _prms )
        {
            Dictionary<string, OracleParameter> dbPrmList = GetPrmsList(_sqlStr);
            Dictionary<string, object> prmsValList = new Dictionary<string, object>();
            foreach (var propInfp in _prms.GetType().GetProperties())
            {
                var parameterName = propInfp.Name.ToUpper();
                var prmValue = propInfp.GetValue(_prms);
                prmsValList.Add(parameterName, prmValue);
            }
            SetParameterValue(dbPrmList, prmsValList);
            return dbPrmList;
        }

        private Dictionary<string, OracleParameter> FillParameterValues<T>(string _sqlStr, T _prms, string _mapperTemplate)
        {
            Dictionary<string, OracleParameter> dbPrmList = GetPrmsList(_sqlStr);
            Dictionary<string, object> prmsValList = new Dictionary<string, object>();
            FillParametersValuesList<T>(prmsValList, _prms, _mapperTemplate);
            SetParameterValue(dbPrmList, prmsValList);
            
            return dbPrmList;
        }

        private void FillParametersValuesList<T>(Dictionary<string, object> _prmsValList, T _prms, string _mapperTemplate)
        {
            foreach (var propInfp in _prms.GetType().GetProperties())
            {
                foreach (var attr in propInfp.CustomAttributes)
                {
                    var prm = GetParameterCustomAttribute(attr);
                    if (prm != null)
                    {
                        if (TemplatesContain(prm.MapperTemplates , _mapperTemplate))
                        {
                            if(prm.IsContainer==false)
                            {
                                var prmValue = propInfp.GetValue(_prms);
                                _prmsValList.Add(prm.ParameterName.ToUpper(), prmValue);
                            }
                            else
                            {
                                var prmValue = propInfp.GetValue(_prms);
                                FillParametersValuesList(_prmsValList, prmValue, _mapperTemplate);
                            }
                        }
                    }
                }
            }
        }

        private ParametersMapper GetParameterCustomAttribute(CustomAttributeData attr)
        {
            if (attr.AttributeType == typeof(ParametersMapper))
            {
                ParametersMapper prmsData = new ParametersMapper();
                var parameterNames = (from p in attr.NamedArguments where p.MemberName == "ParameterName" select p);
                if (parameterNames.Count() > 0)
                {
                    prmsData.ParameterName = (string)parameterNames.First().TypedValue.Value;
                }
                var parameterTemplates = (from p in attr.NamedArguments where p.MemberName == "MapperTemplates" select p);
                if (parameterTemplates.Count() > 0)
                {
                    prmsData.MapperTemplates = (string)parameterTemplates.First().TypedValue.Value;
                }
                var parameterIsContainers = (from p in attr.NamedArguments where p.MemberName == "IsContainer" select p);
                if (parameterIsContainers.Count() > 0)
                {
                    prmsData.IsContainer = (bool)parameterIsContainers.First().TypedValue.Value;
                }
                return prmsData;
            }
            else
                return null;
        }

        private DataFieldMapper GetDataFieldCustomAttribute(CustomAttributeData attr)
        {
            if (attr.AttributeType == typeof(DataFieldMapper))
            {
                DataFieldMapper fieldData = new DataFieldMapper();
                var fieldNames = (from p in attr.NamedArguments where p.MemberName == "FieldName" select p);
                if (fieldNames.Count() > 0)
                {
                    fieldData.FieldName = (string)fieldNames.First().TypedValue.Value;
                }
                var fieldTemplates = (from p in attr.NamedArguments where p.MemberName == "MapperTemplates" select p);
                if (fieldTemplates.Count() > 0)
                {
                    fieldData.MapperTemplates = (string)fieldTemplates.First().TypedValue.Value;
                }
                var fieldIsContainers = (from p in attr.NamedArguments where p.MemberName == "IsContainer" select p);
                if (fieldIsContainers.Count() > 0)
                {
                    fieldData.IsContainer = (bool)fieldIsContainers.First().TypedValue.Value;
                }
                return fieldData;
            }
            else
                return null;
        }

        private bool TemplatesContain(string _propTemplates, string _actionTemplates)
        {
            var actionTemplates = _actionTemplates.Split(',');
            var propTemplates = _propTemplates.Split(',');
            foreach (var tmp in actionTemplates)
            {
                if (propTemplates.Contains(tmp))
                    return true;
            }
            return false;
        }

        private void SetParameterValue(Dictionary<string, OracleParameter> _dbPrmsList, Dictionary<string, object> _prmsValList)
        {
            foreach(var dbPrm in _dbPrmsList)
            {
                var prmsVals = from p in _prmsValList where p.Key == dbPrm.Key select p;
                if(prmsVals.Count() > 0)
                {
                    var prmValue=prmsVals.First().Value;
                    if (prmValue.GetType().Name == dbPrm.Value.DbType.ToString())
                        dbPrm.Value.Value = prmValue;
                    else
                        throw new Exception("Type Mismatch Parameter Name : " + dbPrm.Value.ParameterName + " Parameter Type : " + dbPrm.Value.DbType.ToString());
                }
            }
        }

        private Dictionary<string, OracleParameter> GetPrmsList(string _sqlStr)
        {
            Dictionary<string, OracleParameter> result = new Dictionary<string, OracleParameter>();
            try
            {
                OracleConnection cnn = new OracleConnection(cnnStr);
                OracleCommand cmd = new OracleCommand(_sqlStr, cnn) { CommandType = System.Data.CommandType.StoredProcedure };
                cnn.Open();
                OracleCommandBuilder.DeriveParameters(cmd);
                cnn.Close();
                foreach (OracleParameter prm in cmd.Parameters)
                {
                    result.Add(prm.ParameterName, prm);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        #endregion
    }
}
