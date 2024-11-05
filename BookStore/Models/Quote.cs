using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStore.Models
{
    public class Quote:SharedProperites
    {
        [Key]
        public Guid QuoteId { get; set; }
        [DisplayName("Quote Text")]
        public string QuoteText { get; set; }
        //public string? QuoteImagePath { get; set; }
    }
}
