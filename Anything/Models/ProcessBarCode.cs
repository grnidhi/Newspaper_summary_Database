using System.ComponentModel.DataAnnotations;

namespace Anything.Models
{
    public class ProcessBarCode
    {
        [Key]
        public int BarCodeId { get; set; }

        public int Opid { get; set; }

        public string ParcodeType { get; set; }
    }
}
