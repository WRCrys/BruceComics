using System.Threading.Tasks;
using DevCA.Business.Interfaces;
using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Interfaces.Service;
using DevCA.Business.Model;
using DevCA.Business.Model.Validations;

namespace DevCA.Business.Services
{
    public class BookGenderService : BaseService, IBookGenderService
    {
        private readonly IBookGenderRepository _repository;
        
        public BookGenderService(INotificator notificator, IBookGenderRepository repository) : base(notificator)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task Add(BookGender bookGender)
        {
            if (!ExecuteValidation(new BookGenderValidation(), bookGender)) return;
            
            await _repository.Add(bookGender);
        }

        public async Task Update(BookGender bookGender)
        {
            if (!ExecuteValidation(new BookGenderValidation(), bookGender)) return;
            
            await _repository.Update(bookGender);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }
    }
}