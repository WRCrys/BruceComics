using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Model;
using DevCa.Data.Context;

namespace DevCa.Data.Repository
{
    public class BookGenderRepository : Repository<BookGender>, IBookGenderRepository
    {
        public BookGenderRepository(BruceComicsContext db) : base(db) { }
    }
}