using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioSonda.Web.Utilities
{
    public sealed class Maior18anosAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string message = string.Format("O {0} é inválido.", validationContext.DisplayName ?? validationContext.MemberName);

            if (value == null)
                return new ValidationResult(message);

            DateTime date;
            try { date = Convert.ToDateTime(value); }
            catch (InvalidCastException e) { return new ValidationResult(message); }

            if (DateTime.Today.AddYears(-18) >= date)
                return ValidationResult.Success;
            else
                return new ValidationResult("Deve possuir mais de 18 anos.");
        }
    }
}