using System.Threading.Tasks;
using DevCA.Business.Interfaces;
using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Interfaces.Service;
using DevCA.Business.Model;
using DevCA.Business.Model.Validations;

namespace DevCA.Business.Services
{
    public class ReserveService : BaseService, IReserveService
    {
        private readonly IReserveRepository _repository;
        
        public ReserveService(INotificator notificator, IReserveRepository repository) : base(notificator)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public async Task Add(Reserve reserve)
        {
            if (!ExecuteValidation(new ReserveValidation(), reserve)) return;
            
            await _repository.Add(reserve);
        }

        public async Task Update(Reserve reserve)
        {
            if (!ExecuteValidation(new ReserveValidation(), reserve)) return;
            
            await _repository.Update(reserve);
        }

        public async Task Remove(long id)
        {
            await _repository.Remove(id);
        }
    }
}