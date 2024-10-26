using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Author:SharedProperites
    {


        [Key]
        public Guid AuthorId { get; set; }
        [Required]
        [DisplayName("Author Name")]
        public string AuthorName { get; set; }
        [Required]
        [DisplayName("Facebook Link")]
        public string? FbLink { get; set; }
        [Required]
        [DisplayName("Instagram Link")]
        public string? InstaLink { get; set; }
        [Required]
        [DisplayName("LinkedIn Link")]
        public string? LinkedInLink { get; set; }
        [Required]
        [DisplayName("X Link")]
        public string? XLink { get; set; }
        public string? AuthorImagePath { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>(); 
        public virtual ICollection<Essay> Essays { get; set; } = new List<Essay>(); 
    }


}
