using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anything.Models
{
    public class LineMaster
    {
        [Key]
        [DisplayName("Sr.No")]
        public int LineId { get; set; }

        [Required]
        [DisplayName("Line")]
        public string LineName { get; set; }
    }
}
