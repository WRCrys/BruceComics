using System;
using System.ComponentModel.DataAnnotations;

namespace DevCa.Api.ViewModels
{
    public class BookGenderViewModel
    {
        [Key]
        public long Id { get; set; }
        
        public long BookId { get; set; }
        
        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(200, ErrorMessage = "The {0} needs to has a length between {2} and {1}", MinimumLength = 2)]
        public string Name { get; set; }

        public BookViewModel Book { get; set; }

        public DateTime DateRegistration { get; set; }
    }
}