using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevCA.Business.Model;

namespace DevCa.Api.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public long Id { get; set; }
        
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(200, ErrorMessage = "The {0} needs to has a length between {2} and {1}", MinimumLength = 2)]
        public string Name { get; set; }

        public long BookGenderId { get; set; }

        public long UserCreationId { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        public string Synopsis { get; set; }

        public IEnumerable<BookGenderViewModel> BookGenders { get; set; }

        public IEnumerable<ReserveViewModel> Reserves { get; set; }

        public UserViewModel UserCreation { get; set; }
    }
}