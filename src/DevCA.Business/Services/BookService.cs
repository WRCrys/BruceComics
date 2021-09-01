using System.Threading.Tasks;
using DevCA.Business.Interfaces;
using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Interfaces.Service;
using DevCA.Business.Model;
using DevCA.Business.Model.Validations;

namespace DevCA.Business.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IBookRepository _repository;
        
        public BookService(INotificator notificator, IBookRepository repository) : base(notificator)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task Add(Book book)
        {
            if (!ExecuteValidation(new BookValidation(), book)) return;

            await _repository.Add(book);
        }

        public async Task Update(Book book)
        {
            if (!ExecuteValidation(new BookValidation(), book)) return;

            await _repository.Update(book);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }
    }
}