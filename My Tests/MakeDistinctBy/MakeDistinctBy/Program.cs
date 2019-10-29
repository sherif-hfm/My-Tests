using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeDistinctBy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> Persons = new List<Person>();
            Persons.Add(new Person() { Id = "1", Name = "Sherif" });
            Persons.Add(new Person() { Id = "1", Name = "Sherif2" });
            Persons.Add(new Person() { Id = "2", Name = "Ahmed" });

            var newPersons = Persons.DistinctBy(p => p.Id).ToList() ;
        }

        
    }

    public static class exMethods
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }

    public class Person
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
