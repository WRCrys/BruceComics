using System;
using System.Threading.Tasks;
using DevCA.Business.Model;

namespace DevCA.Business.Interfaces.Service
{
    public interface IReserveService : IDisposable
    {
        Task Add(Reserve reserve);

        Task Update(Reserve reserve);

        Task Remove(long id);
    }
}