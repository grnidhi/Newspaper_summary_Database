using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Anything.Models
{
    public class ProcessM
    {
        [DisplayName("SrNo")]
        [Key]
        public int ProcessId { get; set; }
        [Required]
        [StringLength(75)]
        public string ProcessName { get; set; }
        [Required]
        [StringLength(255)]
        public string ProcessDescrption { get; set; }

    }
}