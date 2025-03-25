using System.ComponentModel.DataAnnotations;

namespace Anything.Models
{
    public class OrderMDetail
    {
        [Key]
        public int Id { get; set; }
        public int Oid { get; set; }
        public string Barcode { get; set; }


    }
}
