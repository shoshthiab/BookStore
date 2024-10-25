using System.ComponentModel;

namespace BookStore.Models
{
    public class SharedProperites
    {
        [DisplayName("Is Active?")]
        public bool IsActive { get; set; }

        [DisplayName("Is Deleted?")]
        public bool IsDeleted { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
    }
}
