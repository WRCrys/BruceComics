using System.Collections.Generic;

namespace DevCA.Business.Model
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool Administrator { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public IEnumerable<Reserve> Reserves { get; set; }
    }
}