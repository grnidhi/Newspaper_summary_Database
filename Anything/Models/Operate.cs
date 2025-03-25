using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Anything.Models
{
    public class Operate
    {
        [Key]
        public int OpId { get; set; }

        [Required]
        [DisplayName("Drawing Number")]
        public int DrawingId { get; set; }
        [ForeignKey("DrawingId")]
        public Draw DrawingMaster { get; set; }

        [Required]
        [DisplayName("Stages")]
        public int StageId { get; set; }
        [ForeignKey("StageId")]
        public StageMaster Stage { get; set; }

        [Required]
        [DisplayName("Opertor Name")]
        public string OperatorName { get; set; }

        [Required]
        [DisplayName("Operator Code")]
        public string OperatorCode { get; set; }

        [Required]
        [DisplayName("Line")]
        public int LineId { get; set; }
        [ForeignKey("LineId")]
        public LineMaster Line { get; set; }


        [Required]
        [DisplayName("Select Shift")]
        public int ShiftId { get; set; }
        [ForeignKey("ShiftId")]
        public SelectShift Select { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Select Date")]
        public DateOnly Date { get; set; }
    }
}