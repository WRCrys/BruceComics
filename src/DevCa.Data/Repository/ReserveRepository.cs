using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Model;
using DevCa.Data.Context;

namespace DevCa.Data.Repository
{
    public class ReserveRepository : Repository<Reserve>, IReserveRepository
    {
        public ReserveRepository(BruceComicsContext db) : base(db) { }
    }
}