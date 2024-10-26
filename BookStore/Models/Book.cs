using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book:SharedProperites
    {
        [Key]
        public Guid BookId { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        public string BookTitle { get; set; } = string.Empty;
        [Required] 
        public lang Language {  get; set; }
        public field Topic {  get; set; }

        [Display(Name = "Availability")]
        public availability Available {  get; set; }

        public decimal Price {  get; set; }
        public currency Currency { get; set; }

        [Display(Name = "Available Quantity")]
        public int AvailableQuantity { get; set; }
        [Display(Name = "Author Name")]

        // public string AuthorName { get; set; }
        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }

        // Navigation property to the Author
        public virtual Author? Author { get; set; }

        public string? BookImagePath { get; set; }
        public enum availability
        {
            [Display(Name = "Sold Out")]
            SoldOut,

            [Display(Name = "Available")]
            Available
        }
        public enum currency
        {
           JOD, USD, EUR, EGP
        }

        public enum lang
        {
            Arabic, English
        }
        public enum field
        {
            Mystery, Thriller, Science, Fantasy, Romance, Historical, Biography, Children, Stories
        }
    

    }
}
