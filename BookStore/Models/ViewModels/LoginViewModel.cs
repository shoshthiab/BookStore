using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStore.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your username")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
