using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace PropertyCustomAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDataModel myvar = new MyDataModel() { EmpName = "Sherif" };
            MyDataModel myvar2 = new MyDataModel() { EmpName = "Sherif2" };
            var attrbs = MyDataModel.GetAttribute<MyDataModel>(myvar, "EmpName", "DatabaseField");
            Type asd = typeof(string);
            var propValue = MyDataModel.GetPropertyValue(myvar, "EmpName");
            myvar.GetType().GetProperty("EmpName").SetValue(myvar2, propValue);
        }
    }

    public class MyDataModel
    {
        [DatabaseMapping(DatabaseField="EmpName")]
        public string EmpName { get; set; }

        public static string GetAttribute<T>(T _myObj,string _propertyName,string _attributeName)
        {
            var attributs = System.Attribute.GetCustomAttributes(_myObj.GetType().GetProperty(_propertyName));
            var arrValue = ((DatabaseMapping)attributs[0]).DatabaseField;
            return arrValue;
        }
        public static object GetPropertyValue(object _myObj, string _propertyName)
        {
            var prop = _myObj.GetType().GetProperty(_propertyName).GetValue(_myObj);
            return prop;
        }
    }

    public class DatabaseMapping:System.Attribute
    {
        public string DatabaseField { get; set; }
    }
}
