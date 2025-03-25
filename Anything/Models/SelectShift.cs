using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anything.Models
{
    public class SelectShift
    {
        [Key]
        [DisplayName("Sr.No")]
        public int ShiftId { get; set; }

        [Required]
        [DisplayName("Shift")]
        public string ShiftName { get; set; }
    }
}
