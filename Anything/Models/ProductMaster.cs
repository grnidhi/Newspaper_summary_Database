using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anything.Models
{
    public class ProductMaster
    {
        [DisplayName("SrNo")]
        [Key]
        public int ProductId { get; set; }
        public string ProductNumber { get; set; }

        [Required]
        [DisplayName("Customer Name")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }


        [Required]
        [DisplayName("Drawing Number")]
        public int DrawingId { get; set; }
        [ForeignKey("DrawingId")]
        public Draw DrawingMaster { get; set; }
    }
}
