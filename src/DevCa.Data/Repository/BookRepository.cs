using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Model;
using DevCa.Data.Context;

namespace DevCa.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BruceComicsContext db) : base(db) { }
    }
}