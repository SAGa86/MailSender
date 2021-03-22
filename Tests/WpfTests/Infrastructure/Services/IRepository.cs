using System.Collections.Generic;
using WpfTests.Models.Base;

namespace WpfTests.Infrastructure.Services
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Add(T item);
        void Update(T item);
        bool Remove(int id);
    }
}
