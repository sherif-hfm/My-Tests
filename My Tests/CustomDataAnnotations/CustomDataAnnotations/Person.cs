using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataAnnotations
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required(ValidationGroup = "G1")]
        [MaxLength(5,ErrorMessage ="Lenght Error")]
        public String PersonName { get; set; }

        [Required(ErrorMessage = "PersonAddress Required")]
        public String PersonAddress { get; set; }

        //[Action(ValidateClass= "CustomDataAnnotations.Person", ValidateFunction = "myValidateFunction", ErrorMessage = "Age should be > 0")]
        public int Age { get; set; }

        [Required]
        [ValidateObject]
        public ContactInfo ContactInfo { get; set; }

        public bool myValidateFunction(int value)
        {
            return false;
        }

    }

    public class ContactInfo
    {
        [Required(ErrorMessage = "Mobile Needed")]
        public string  Mobile { get; set; }
    }


    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public string ValidationGroup { get; set; }
    }

    public class ValidateObjectAttribute : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(value, null, null);

                Validator.TryValidateObject(value, context, results, true);
                List<string> resultsMsgs = new List<string>();
                if (results.Count != 0)
                {
                    resultsMsgs.Add(FormatErrorMessage(validationContext.DisplayName));
                    results.ForEach(x => { resultsMsgs.Add(x.ErrorMessage); });
                    return new ValidationResult("", resultsMsgs);
                }
            }
            return ValidationResult.Success;
        }
    }


    public static  class RmValidator 
    {
        public static bool Validate(object instance,  List<ValidationResult>  validationResults,string validationGroup)
        {
            var ctx = new ValidationContext(instance);
            List<ValidationResult> result = new List<ValidationResult>();
            Validator.TryValidateObject(instance, ctx, result);
            foreach(var vResult in result)
            {
                var proInfo= instance.GetType().GetProperty(vResult.MemberNames.First());
                foreach(var  cstAttrs in proInfo.CustomAttributes)
                {
                    if(cstAttrs.AttributeType.FullName.Contains("DataAnnotations"))
                    {
                        var groups = (from p in cstAttrs.NamedArguments where p.MemberName == "ValidationGroup" select p);
                        if(groups.Count() > 0)
                        {
                            var group = groups.First();
                            if (group.TypedValue.Value.ToString() == validationGroup)
                                validationResults.Add(vResult); 
                        }
                    }
                }
            }
            if (validationResults.Count > 0)
                return false;
            else
                return true;
        }
    }

    public class ActionAttribute : ValidationAttribute
    {
        public string ValidateFunction { get; set; }
        public string ValidateClass { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var obj= System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(ValidateClass);
            if(obj != null)
            {
                var result = obj.GetType().GetMethod(ValidateFunction).Invoke(obj, new object[] { value });
                if(result is bool)
                {
                    if((bool)result == false)
                    {
                        List<string> resultsMsgs = new List<string>();
                        resultsMsgs.Add(FormatErrorMessage(validationContext.DisplayName));
                        return new ValidationResult("", resultsMsgs);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }

    
}
