using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCExtending.Models
{
    public class Person
    {
        [Required]
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public Address Address { get; set; }

        [UIHint("SpecialDateTime")]
        public string BirthDate { get; set; }
    }
}