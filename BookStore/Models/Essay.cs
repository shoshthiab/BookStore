using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Essay:SharedProperites
    {       public Guid EssayId { get; set; }
            [DisplayName("Essay Title")]
            public string EssayTitle { get; set; }
            [DisplayName("Essay Description")]
            public string EssayDescription { get; set; }
            [DisplayName("Essay Author")]
            public string? EssayAuthor { get; set; }
            public string? EssayImagePath { get; set; }

            // public string AuthorName { get; set; }
            [ForeignKey("Author")]
            public Guid AuthorId { get; set; }

            // Navigation property to the Author
            public virtual Author? Author { get; set; }

    }
}
