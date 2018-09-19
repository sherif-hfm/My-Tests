using MVCBasics.AppCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBasics.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        [DisplayName("Person Name")]
        public string PersonName { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        //[Required(ErrorMessage = "Person Address is required ")]
        //[DisplayName("Person Address")]
        //[StringLength(160, MinimumLength = 10)]
        //[DataType(DataType.MultilineText)]
        public string PersonAddress { get; set; }

        //[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [DisplayName("Person Age")]
        [Required(ErrorMessage = "Person Age is required ")]
        //[RegularExpression("([0-9]+)")]
        [CustomValidation1(1)]
        public int PersonAge { get; set; }
        
        [Required]
        [DisplayName("User Login")]
        [StringLength(20, MinimumLength = 5)]
        [Remote("CheckUserLogin", "Person", ErrorMessage = "{0} is Exist ")] // {0} will be property name or display name
        public string UserLogin { get; set; }

        public bool Status { get; set; }
    }
}