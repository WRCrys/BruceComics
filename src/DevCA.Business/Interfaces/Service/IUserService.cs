using System;
using System.Threading.Tasks;
using DevCA.Business.Model;

namespace DevCA.Business.Interfaces.Service
{
    public interface IUserService : IDisposable
    {
        Task Add(User user);

        Task Update(User user);

        Task Remove(long id);

        Task VerifyAuth(string email, string password);
    }
}