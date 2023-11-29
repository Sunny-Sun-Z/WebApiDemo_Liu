using System.ComponentModel.DataAnnotations;

namespace WebApiDemo_Liu.Models.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = validationContext.ObjectInstance as Shirt;
            if (shirt != null && !string.IsNullOrEmpty(shirt.Gender))
            {
                if(shirt.Gender.Equals("men",StringComparison.OrdinalIgnoreCase)&& shirt.Size < 8)
                {
                    return new ValidationResult("The men`s shirt size has to be greater than or equal to 8.");
                }
                else if (shirt.Gender.Equals("wemen", StringComparison.OrdinalIgnoreCase) && shirt.Size < 6)
                {
                    return new ValidationResult("The wemen`s shirt size has to be greater than or equal to 6.");
                }
            }
           return ValidationResult.Success;
        }
    }
}
