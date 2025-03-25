using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anything.Models
{
    public class StageMaster
    {
        [DisplayName("SrNo")]
        [Key]
        public int StageId { get; set; }

        [Required]
        public string StageName { get; set; }

        [Required]
        public string StageDescription { get; set; }

        [Required]
        [DisplayName("Process Name")]
        public int ProcessId { get; set; }
        [ForeignKey("ProcessId")]
        public ProcessM Name{ get; set; }

        [Required]
        [DisplayName("Drawing Number")] 
        public int DrawingId { get; set; }
        [ForeignKey("DrawingId")]
        public Draw DrawingMaster { get; set; }
    }
}
