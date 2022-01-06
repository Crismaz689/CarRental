using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRental.App.Models
{
    public class UserRegistrationViewModel
    {
        [Required(ErrorMessage = "You have to enter username!")]
        [MaxLength(24, ErrorMessage = "Username max length is 24!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You have to enter password!")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "You have to confirm your password!")]
        [Compare("Password", ErrorMessage = "Entered passwords are not equal!")]
        public string ConfirmPassword { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "You have to enter your first name!")]
        [MaxLength(24, ErrorMessage = "First name max length is 32!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You have to enter your surname!")]
        [MaxLength(24, ErrorMessage = "Surname max length is 32!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "You have to enter your PESEL!")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "PESEL ALWAYS contains 11 digits!")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "PESEL contains only digits!")]
        public string Pesel { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        [DataType("decimal")]
        [Range(10, 1000000000, ErrorMessage = "You have to enter amount between 10$ - 1 000 000 000$")]
        public decimal Balance { get; set; }
    }
}
