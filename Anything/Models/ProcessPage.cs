using System.ComponentModel.DataAnnotations;

namespace Anything.Models
{
    public class ProcessPage
    {
        [Key]
        public int ProcessPageId { get; set; }

        public int OpId { get; set; }

        public int QcMId { get; set; }


    }
}
