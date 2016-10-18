using System.Collections.Generic;

namespace CommunityTools.DataAccess.Common
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        void Add(T item);
        void Update(T item);
        void Remove(T item);
        void Delete(T entity);
    }
}