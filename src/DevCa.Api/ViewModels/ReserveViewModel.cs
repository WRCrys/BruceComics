using System;
using System.ComponentModel.DataAnnotations;

namespace DevCa.Api.ViewModels
{
    public class ReserveViewModel
    {
        [Key]
        public long Id { get; set; }
        
        public long UserId { get; set; }

        public long BookId { get; set; }

        public long Returned { get; set; }

        public UserViewModel User { get; set; }

        public BookViewModel Book { get; set; }

        public DateTime DateRegistration { get; set; }
    }
}