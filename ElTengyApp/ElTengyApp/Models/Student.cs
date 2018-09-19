using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElTengyApp.Models
{
    public class Student
    {
        public String Id { get; set; }

        public String Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int Sex { get; set; } // 0 male 1 famle

        public string Encrypt()
        {
            var result=  JsonConvert.SerializeObject(this);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(result);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
