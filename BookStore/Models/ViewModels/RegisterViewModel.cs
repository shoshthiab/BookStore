using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStore.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter username")]
        [DisplayName("User Name")]
        public string UserName { get; set; }


        [DisplayName("Email")]
        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Confirm Email")]
        [Required(ErrorMessage = "Please enter confirm email")]
        [EmailAddress]
        [Compare("Email", ErrorMessage = "Emails not match")]
        public string ConfirmEmail { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Please enter confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter mobile phone")]
        [DisplayName("Mobile Phone")]
        public string MobileNumber { get; set; }


    }
}
