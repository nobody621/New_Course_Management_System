using System.Collections.Generic;

namespace Course_Management_System
{
    public interface IDataAccess<T>
    {
        bool Add(T entity);
        bool Delete(int entityId);
        bool Update(T entity);
        List<T> GetAll();
    }
}