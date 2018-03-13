using System.Collections.Generic;

namespace CorsoEnaip2018_SuperHeroes.DataAccess
{
    public interface IRepository<T>
    {
        List<T> FindAll();
        T Find(int id);
        void Update(T model);
        void Insert(T model);
        void Delete(T model);
    }
}
