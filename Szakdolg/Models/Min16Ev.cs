using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Szakdolg.Models
{
    public class Min16Ev : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ugyfel = (RegisterViewModel)validationContext.ObjectInstance;


            if (ugyfel.Datum == null)
                return new ValidationResult("A születési dátum megadása kötelező!");

            var kor = DateTime.Today.Year - ugyfel.Datum.Value.Year;

            return (kor >= 16)
                ? ValidationResult.Success
                : new ValidationResult("csíra vagy még ehhez gyerek!");
        }
    }
}