using System.Collections.Generic;

namespace DevCA.Business.Model
{
    public class Book : Entity
    {
        public string Name { get; set; }

        public long BookGenderId { get; set; }

        public long UserCreationId { get; set; }

        public string Synopsis { get; set; }

        public IEnumerable<BookGender> BookGenders { get; set; }

        public IEnumerable<Reserve> Reserves { get; set; }

        public User UserCreation { get; set; }
    }
}