using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevCa.Api.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public long Id { get; set; }
        
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(140, ErrorMessage = "The {0} needs to has a length between {2} and {1}", MinimumLength = 7)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(20, ErrorMessage = "The {0} needs to has a length between {2} and {1}", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "We need to know if you're an administrator")]
        public bool Administrator { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }

        public IEnumerable<ReserveViewModel> Reserves { get; set; }
    }
}