using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBasics.Models
{
    public class Country : IValidatableObject
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //yield return new ValidationResult("Country Name is inva!",new[] { "CountryName" });
            throw new NotImplementedException();
        }
    }
}