using HotelManagement.Common.Interfaces;
using HotelManagement.DataContracts.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelManagement.DataServices.Implementation
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IIdentifiable, new()
    {
        public readonly Entities DbContext;
        protected abstract string TableName { get; }

        protected GenericRepository(Entities dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public T GetById(object id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetWithInclude(Expression<Func<T, bool>> predicate, params string[] include)
        {
            IQueryable<T> query = DbContext.Set<T>();
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        public bool Save(T entity)
        {
            DbContext.Set<T>().Add(entity);
            return true;
        }

        public bool Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            return true;
        }

        public bool AddRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().AddRange(entities);
            return true;
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
            return true;
        }

        public bool Save(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Save(entity);
            }
            return true;
        }

        public bool UpdateAllPropertiesOf(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool UpdateSpecificPropertiesOf(T entity, params Expression<Func<T, object>>[] modifiedProperties)
        {
            if (modifiedProperties.Length == default)
                throw new ArgumentException(Common.Constants.General.NO_MODIFIED_PROPERTIES_ERROR, nameof(modifiedProperties));

            DbContext.Set<T>().Attach(entity);

            foreach (var modifiedProperty in modifiedProperties)
            {
                DbContext.Entry(entity).Property<object>(modifiedProperty).IsModified = true;
            }

            return true;
        }

        public bool DeleteById(int id)
        {
            T entity = new T { Id = id };

            DbContext.Entry(entity).State = EntityState.Deleted;

            return true;
        }

        public bool Delete(T entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                DbContext.Set<T>().Attach(entity);
            }
            DbContext.Set<T>().Remove(entity);
            return true;
        }

        public void DeleteAll()
        {
            DbContext.Database.ExecuteSqlInterpolated($"DELETE FROM [{TableName}]");
        }
    }
}
