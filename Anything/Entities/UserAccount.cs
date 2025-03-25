using Anything.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Anything.Entities
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Password), IsUnique = true)]
    public class UserAccount
    {
        [Key]
        [Display(Name = "Srno")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "FirstName name is RequiredAttribute.")]
        [MaxLength(50, ErrorMessage = "Max 50  character  allowed")]

        public string Firstname { get; set; }

        [Required(ErrorMessage = "LastName name is RequiredAttribute.")]
        [MaxLength(50, ErrorMessage = "Max 50  character  allowed")]

        public string Lastname { get; set; }


        [Required(ErrorMessage = "UserName name is RequiredAttribute.")]
        [MaxLength(50, ErrorMessage = "Max 50  character  allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage = "UserType name is RequiredAttribute.")]
        public UserType UserType { get; set; }


        [Required(ErrorMessage = "Password  is RequiredAttribute.")]
        [MaxLength(10, ErrorMessage = "Max 10  character  allowed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}