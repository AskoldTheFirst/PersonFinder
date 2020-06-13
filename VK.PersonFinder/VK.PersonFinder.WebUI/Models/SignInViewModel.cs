using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VK.PersonFinder.WebUI.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "User name must be provided.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password must be provided.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RemeberMe { get; set; }
    }
}
