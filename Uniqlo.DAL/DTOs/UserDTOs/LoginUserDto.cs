using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.DAL.DTOs.UserDTOs
{
    public class LoginUserDto
    {
        [Required]
        [Display(Prompt = "Email or Username")]
        public string EmailOrUsername { get; set; }

        [Display(Prompt = "Password")]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool IsPersistant { get; set; }
    }
}
