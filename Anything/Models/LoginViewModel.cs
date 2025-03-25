using Anything.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anything.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName is RequiredAttribute.")]
        [MaxLength(50, ErrorMessage = "Max 50  character  allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password  is RequiredAttribute.")]
        [MaxLength(10, ErrorMessage = "Max 10  character  allowed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Usertype is RequiredAttribute.")]
        public UserType UserType { get; set; }

    }
}