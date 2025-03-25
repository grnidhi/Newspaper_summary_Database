using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Anything.Models
{
    public class StageConn
    {
        [Key]
        public int SCid { get; set; }

        [DisplayName("Select Group")]
        [ForeignKey("Gziee")]
        public int GId { get; set; }

        public Gzie Gziee { get; set; }

        [DisplayName("Current Stage")]
        [ForeignKey("CurrentStage")]
        public int CurrentStageId { get; set; }

        public StageMaster CurrentStage { get; set; }

        [DisplayName("Fail Stage")]
        [ForeignKey("FailStage")]
        public int FailStageId { get; set; }

        public StageMaster FailStage { get; set; }

        [DisplayName("Pass Stage")]
        [ForeignKey("PassStage")]
        public int PassStageId { get; set; }

        public StageMaster PassStage { get; set; }
        public DateTime? CreatedDate { get; internal set; }

    }
}