using BookStore.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class AdsSlider : SharedProperites
    {
        [Key]
        public Guid AdId { get; set; }

        [Required]
        [DisplayName("Ad Title")]
        public string AdTitle { get; set; } = string.Empty;
        [DisplayName("Ad Description")]
        [Required] public string AdDescription { get; set; }= string.Empty;
        [DisplayName("Ad Type")]
        [Required] public AdsType AdType { get; set; }

        public string? AdImagePath { get; set; }
        public enum AdsType
        {
            Book, Bookmark, BookLight, Magazine
        }
    }
}


 
 