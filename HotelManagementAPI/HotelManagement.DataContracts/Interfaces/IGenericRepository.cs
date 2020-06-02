using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManagement.DataContracts.Interfaces
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params string[] include);
        bool Save(T entity);
        bool Add(T entity);
        bool AddRange(IEnumerable<T> entity);
        bool RemoveRange(IEnumerable<T> entities);
        bool Save(IEnumerable<T> entity);
        bool UpdateAllPropertiesOf(T entity);

        bool UpdateSpecificPropertiesOf(T entity, params Expression<Func<T, object>>[] modifiedProperties);

        bool DeleteById(int id);
        bool Delete(T entity);
        void DeleteAll();
    }
}
