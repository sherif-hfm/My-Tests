using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MD5Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string file = @"D:\Originals\Gandalf's_Win8PE_x86.ISO";
            //CreateMd5ForFile(file);
            Person person1 = new Person() { Id = "1", Name = "Sherif", BirthDate = new DateTime(1976, 9, 28) };
            Person person2 = new Person() { Id = "1", Name = "Sherif", BirthDate = new DateTime(1976, 9, 28) };
            var hash1=CreateMd5ForObject<Person>(person1);
            var hash2 = CreateMd5ForObject<Person>(person2);
        }

        private static void CreateMd5ForFile(string filePath)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = File.ReadAllBytes(filePath);
            byte[] hash = md5.ComputeHash(inputBytes);
           
            var result= Convert.ToBase64String(hash);
        }

        private static string CreateMd5ForObject<T>(T obj)
        {
            
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            var json = JsonConvert.SerializeObject(obj);
            byte[] inputBytes = Encoding.UTF8.GetBytes(json); ;
            byte[] hash = md5.ComputeHash(inputBytes);
            var result = Convert.ToBase64String(hash);
            return result;
        }
    }

    public class Person
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

    }
}
