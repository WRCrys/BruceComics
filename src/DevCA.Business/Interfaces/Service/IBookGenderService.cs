using System;
using System.Threading.Tasks;
using DevCA.Business.Model;

namespace DevCA.Business.Interfaces.Service
{
    public interface IBookGenderService : IDisposable
    {
        Task Add(BookGender bookGender);

        Task Update(BookGender bookGender);

        Task Remove(long id);
    }
}