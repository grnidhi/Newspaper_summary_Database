using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anything.Models
{
    public class Gzie
    {
        [DisplayName("SrNo")]
        [Key]
        public int GId { get; set; }

        [Required]
        [DisplayName("Group Name")]
        public string GName { get; set; }

        [Required]
        [DisplayName("Process Name")]
        public int ProcessId { get; set; }
        [ForeignKey("ProcessId")]
        public ProcessM Processname { get; set; }

        [Required]
        [DisplayName("Stages")]
        public int StageId { get; set; }
        [ForeignKey("StageId")]
        public StageMaster Stages { get; set; }

    }
}
