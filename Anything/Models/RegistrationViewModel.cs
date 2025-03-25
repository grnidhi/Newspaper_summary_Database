
using System.ComponentModel.DataAnnotations;

namespace Anything.Models
{
    public class RegistrationViewModel
    {

        [Required(ErrorMessage = "FirstName is RequiredAttribute.")]
        [MaxLength(50, ErrorMessage = "Max 50  character  allowed")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "LastName is RequiredAttribute.")]
        [MaxLength(50, ErrorMessage = "Max 50  character  allowed")]
        public string Lastname { get; set; }


        [Required(ErrorMessage = "UserName is RequiredAttribute.")]
        [MaxLength(50, ErrorMessage = "Max 50  character  allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password  is RequiredAttribute.")]
        [MaxLength(10, ErrorMessage = "Max 10  character  allowed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Usertype  is RequiredAttribute.")]
        public UserType UserType { get; set; }
    }
}