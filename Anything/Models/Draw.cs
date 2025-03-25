using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anything.Models
{
    public class Draw
    {
        [Key]
        [DisplayName("SrNo")]
        public int DrawingId { get; set; }

        [Required]
        public string ProductNumber { get; set; }

        [Required]
        [DisplayName("Product Type")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }


        [Required]
        [DisplayName("Process Type")]
        public int ProcessId { get; set; }
        [ForeignKey("ProcessId")]
        public ProcessM process { get; set; }


    }
}