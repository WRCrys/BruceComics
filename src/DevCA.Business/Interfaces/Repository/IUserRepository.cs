using System.Threading.Tasks;
using DevCA.Business.Model;

namespace DevCA.Business.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Auth(string email, string password);
    }
}