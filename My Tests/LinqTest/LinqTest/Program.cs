using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person() { Age=42, Name="Sherif" });
            persons.Add(new Person() { Age = 30, Name = "Ahmed" });
            int age = 20;
            var data = from p in persons where p.Age > age select p;
            age = 35;
            var date2 = data.ToList();

            date2.ForEach(e => { Console.WriteLine("A"); });
        }
    }

    public class Person
    {
        public int Age { get; set; }

        public string Name { get; set; }
    }
}

