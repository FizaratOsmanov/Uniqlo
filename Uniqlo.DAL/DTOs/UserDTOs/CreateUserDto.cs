using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.DAL.DTOs.UserDTOs
{
    public class CreateUserDto
    {

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Display(Prompt = "FirstName")]
        public string FirstName { get; set; }

        ////////////////////////////////////////////////////////

        [Required, Length(2, 50)]
        [Display(Prompt = "LastName")]
        public string LastName { get; set; }

        /////////////////////////////////////////////////////////

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "Email")]
        public string Email { get; set; }

        /////////////////////////////////////////////////////////

        [Required]
        [Length(2, 30)]
        [Display(Prompt = "Username")]
        public string Username { get; set; }

        /// //////////////////////////////////////////////////////

        [DataType(DataType.Password)]
        [Display(Prompt = "Password")]
        public string Password { get; set; }

        /////////////////////////////////////////////////////////

        [DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Password do not match")]
        [Display(Prompt = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        ////////////////////////////////////////////////////////



    }
}
