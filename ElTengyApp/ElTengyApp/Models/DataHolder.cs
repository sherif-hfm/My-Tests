using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElTengyApp.Models
{
    public class DataHolder
    {
        public string Id { get; set; }

        public string Data { get; set; }

        public static Student Decrypt(string _data)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(_data);
            var plantext= System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            return  JsonConvert.DeserializeObject<Student>(plantext);
        }
    }
}
