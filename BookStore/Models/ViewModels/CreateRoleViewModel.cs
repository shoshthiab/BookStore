using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class CreateRoleViewModel
    {
            [Required]
            public string Name { get; set; }

       
    }
}
