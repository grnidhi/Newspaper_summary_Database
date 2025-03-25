using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anything.Models
{
    public class Customer
    {
        [DisplayName("SrNo")]
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
    }
}