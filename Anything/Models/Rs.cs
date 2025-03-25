using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anything.Models
{
    public class Rs
    {
        [Key]
        [DisplayName("Sr.No")]
        public int RId { get; set; }

       
        [Required]
        public string Reason{ get; set; }
       
        
        [Required]
        [DisplayName("Customers")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }

        
        [Required]
        [DisplayName("Products")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductMaster Product { get; set; }

        
        [Required]
        [DisplayName("Stages")]
        public int StageId { get; set; }
        [ForeignKey("StageId")]
        public StageMaster Stage { get; set; }




    }
}
