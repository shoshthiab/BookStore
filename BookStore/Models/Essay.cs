namespace BookStore.Models
{
    public class Essay:SharedProperites
    {       public Guid EssayId { get; set; }
            public string EssayTitle { get; set; }
            public string EssayDescription { get; set; }
            public string EssayAuthor { get; set; }
            public string? EssayImagePath { get; set; }
        
    }
}
