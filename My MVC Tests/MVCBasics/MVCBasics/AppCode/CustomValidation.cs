using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCBasics.AppCode
{
    public class CustomValidation1 : ValidationAttribute //, IClientValidatable
    {
        public CustomValidation1(object value): base("{0} is invalid")
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            //return new ValidationResult(errorMessage);
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule();
            yield return rule;
        }
    }
}