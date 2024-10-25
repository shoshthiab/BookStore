using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book:SharedProperites
    {
        [Key]
        public Guid BookId { get; set; }

        [Required]
        public string BookTitle { get; set; } = string.Empty;
        [Required] 
        public lang Language {  get; set; }
        public field Topic {  get; set; }
        public availability Available {  get; set; }

        public decimal Price {  get; set; }
        public currency Currency { get; set; }
        public int AvailableQuantity { get; set; }
        public string AuthorName { get; set; }
        public string? BookImagePath { get; set; }
        public enum availability
        {
            soldOut, Available
        }
        public enum currency
        {
           JOD, USD, EUR
        }

        public enum lang
        {
            Arabic, English
        }
        public enum field
        {
            Mystery, Thriller, Science, Fantasy, Romance, Historical, Biography, Children
        }
        public enum Author
        {
            
        }

    }
}
