using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anything.Models
{
    public class QcMaster : QcParameter
    {
        [Key]
        public int QcMId { get; set; }

        [Required]
        public string FormName { get; set; }


        [Required]
        [DisplayName("Customer Name")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }


        [Required]
        [DisplayName("Product Name")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductMaster Product { get; set; }


        [Required]
        [DisplayName("Stage")]
        public int StageId { get; set; }
        [ForeignKey("StageId")]
        public StageMaster Stage { get; set; }

    }
}