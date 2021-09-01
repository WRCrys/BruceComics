using System.Threading.Tasks;
using DevCA.Business.Interfaces;
using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Interfaces.Service;
using DevCA.Business.Model;
using DevCA.Business.Model.Validations;

namespace DevCA.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _repository;
        
        public UserService(INotificator notificator, IUserRepository repository) : base(notificator)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task Add(User user)
        {
            if (!ExecuteValidation(new UserValidation(), user)) return;
            
            await _repository.Add(user);
        }

        public async Task Update(User user)
        {
            if (!ExecuteValidation(new UserValidation(), user)) return;
            
            await _repository.Update(user);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }

        public async Task VerifyAuth(string email, string password)
        {
            var userAuth = await _repository.Auth(email, password);
            
            if (userAuth == null)
            {
                Notify("The email or password provided are incorrect!");
            }

        }
    }
}