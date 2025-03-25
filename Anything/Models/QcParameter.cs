using System.ComponentModel.DataAnnotations;
namespace Anything.Models
{
    public class QcParameter
    {
       
        [Required]
        public string[] ParameterName { get; set; } // Array of strings

        [Required]
        public string[] ParameterTitle { get; set; } // Array of strings

        [Required]
        public string[] ParameterType { get; set; } // Array of strings

        public string[] Min { get; set; } // Array of strings

        public string[] Max { get; set; } // Array of strings
    }
}