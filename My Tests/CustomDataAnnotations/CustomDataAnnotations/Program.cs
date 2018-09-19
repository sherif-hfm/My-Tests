using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataAnnotations
{
    class Program
    {
        static void Main(string[] args)
        {
            Validate();
        }

        private static void Validate()
        {
            Person person = new Person();
            person.PersonName = "asdfghjkl;";
            person.ContactInfo = new ContactInfo();
            var context = new ValidationContext(person,  null,  null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(person, context, results,true);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
        }

        private static void CustomValidate()
        {
            Person person = new Person();
            var ctx = new ValidationContext(person, new Dictionary<object, object>());
            List<ValidationResult> resultList = new List<ValidationResult>();
            var result = RmValidator.Validate(person, resultList, "G1");
        }
    }
}
