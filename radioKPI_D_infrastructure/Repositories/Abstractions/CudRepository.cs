using Microsoft.EntityFrameworkCore;
using radioKPI_D_infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Repositories.Abstractions
{
    internal class CudRepository<T, TKey> : BaseRepository<T, TKey>
        where T : class, IDbEntity
        where TKey : struct, IEquatable<TKey>
    {
        public CudRepository(DbContext context)
            : base(context)
        {

        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }
        public virtual void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
        protected void CompleteTransaction()
        {
            Context.SaveChanges();
        }
    }
}
