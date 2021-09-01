using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevCa.Api.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(140, ErrorMessage = "The {0} needs to has a length between {2} and {1}", MinimumLength = 7)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(20, ErrorMessage = "The {0} needs to has a length between {2} and {1}", MinimumLength = 6)]
        public string Password { get; set; }
    }
}