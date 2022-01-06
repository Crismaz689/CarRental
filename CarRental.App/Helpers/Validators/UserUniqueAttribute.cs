using CarRental.Database;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarRental.App.Helpers.Validators
{
    public class UserUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (CarRentalDbContext)validationContext
                .GetService(typeof(CarRentalDbContext));

            var user = _context.Users.FirstOrDefault(u => u.Username == value.ToString());

            if(user != null)
            {
                return new ValidationResult(ErrorMessage ?? $"Username {value.ToString()} is taken!");
            }

            return ValidationResult.Success;
        }
    }
}
