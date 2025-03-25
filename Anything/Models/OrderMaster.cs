using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Anything.Models
{
    public class OrderMaster
    {
        [Key]
        [DisplayName("Sr No")]
        public int Oid { get; set; }

        // Change datatype to string
        public string OrderNum { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Issue Date")]
        public DateOnly IssueDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Key Date")]
        public DateOnly KeyDate { get; set; }

        [DisplayName("Drawing number")]
        [ForeignKey("Draw")]
        public int DrawingId { get; set; }
        public Draw Draw { get; set; }

        [DisplayName("Product number")]
        [ForeignKey("ProductMasters")]
        public int ProductId { get; set; }
        public ProductMaster ProductMasters { get; set; }

        public int OrderQty { get; set; }

        public string Revision { get; set; }

        public int HSNcode { get; set; }

        public int Itemcode { get; set; }

        public string AddInfo { get; set; }

        public string ProDetail { get; set; }

        // NotMapped property for Barcodes
        [NotMapped]
        public List<string> Barcodes { get; set; } = new List<string>();

        // Mapped property to store Barcodes as JSON
        public string BarcodesSerialized
        {
            get => JsonConvert.SerializeObject(Barcodes);
            set => Barcodes = string.IsNullOrEmpty(value) ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(value);
        }

        public int len { get; set; }

        public string Po { get; set; }

        public string Location { get; set; }

        public int Qty { get; set; }

    }
}