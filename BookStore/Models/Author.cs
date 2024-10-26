using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Author:SharedProperites
    {


        [Key]
        public Guid AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string? FbLink { get; set; }
        [Required]
        public string? InstaLink { get; set; }
        [Required]
        public string? LinkedInLink { get; set; }
        [Required]
        public string? XLink { get; set; }
        public string? AuthorImagePath { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>(); 
    }


}
