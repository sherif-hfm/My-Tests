using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CallOracleStoredProcedure
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ParametersMapper : Attribute
    {
        public string ParameterName { get; set; }
        public string MapperTemplates { get; set; }
        public bool IsContainer { get; set; }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class DataFieldMapper : Attribute
    {
        public string FieldName { get; set; }
        public string MapperTemplates { get; set; }
        public bool IsContainer { get; set; }
        
    }

    public class DataFieldPropertyInfo
    {
        public string FieldName { get; set; }
        
        public PropertyInfo PropertyInfo { get; set; }

        public List<DataFieldPropertyInfo> NestedProperties { get; set; }
    }
}
