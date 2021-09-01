using System;
using System.Threading.Tasks;
using DevCA.Business.Model;

namespace DevCA.Business.Interfaces.Service
{
    public interface IBookService : IDisposable
    {
        Task Add(Book book);

        Task Update(Book book);

        Task Remove(long id);
    }
}