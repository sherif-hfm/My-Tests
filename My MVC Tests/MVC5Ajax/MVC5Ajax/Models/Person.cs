using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Ajax.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        
        [DisplayName("Person Name")]
        [Required]
        [MaxWords(2)]
        public string PersonName { get; set; }
        
        [DisplayName("Person Age")]
        [Required(ErrorMessage = "Person Age is required ")]
        [Range(18, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int PersonAge { get; set; }
    }
}