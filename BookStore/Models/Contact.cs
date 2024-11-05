using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStore.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
       
        public string ContactName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }
        public string ContactMsg { get; set; }
    }
}
