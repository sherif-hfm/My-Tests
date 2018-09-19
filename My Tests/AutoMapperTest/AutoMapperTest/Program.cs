using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<ClassA, ClassB>(); cfg.CreateMap<ClassA1, ClassB1>(); });
            ClassA objectA = new ClassA() { Code = "1", Name = "Object A", Age = 10 };
            objectA.Address = new ClassA1() { CityName = "Sohag", StreetName = "My Street" };
            ClassB objectB = Mapper.Map<ClassB>(objectA);
        }
    }
    class ClassA
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ClassA1 Address { get; set; }
    }

    class ClassB
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ClassB1 Address { get; set; }
    }

    class ClassA1
    {
        public string CityName { get; set; }
        public string StreetName { get; set; }
    }

    class ClassB1
    {
        public string CityName { get; set; }
        public string StreetName { get; set; }
    }
}
