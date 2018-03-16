using System.Collections.Generic;

namespace CorsoEnaip2018_ProjectManagement.DataAccess
{
    public interface IRepository<T>
    {
        List<T> FindAll();
        T Find(int id);
        void Insert(T model);
        bool Update(T model);
        bool Delete(T model);
    }
}
