using System.Linq;
using System.Threading.Tasks;
using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Model;
using DevCa.Data.Context;

namespace DevCa.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BruceComicsContext db) : base(db) { }
        
        public async Task<User> Auth(string email, string password)
        {
            var auth = await Search(a => a.Email == email && a.Password == password);

            return auth.FirstOrDefault();
        }
    }
}