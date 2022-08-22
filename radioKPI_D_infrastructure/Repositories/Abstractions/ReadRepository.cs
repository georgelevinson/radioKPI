using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using radioKPI_D_infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace radioKPI_D_infrastructure.Repositories.Abstractions
{
    internal class ReadRepository<T, TKey> : BaseRepository<T, TKey>
        where T : class, IDbEntity
        where TKey : struct, IEquatable<TKey>
    {
        public ReadRepository(DbContext context)
            : base(context)
        {

        }
        public IEnumerable<T> GetAll()
        {
            return BaseQuery().ToList();
        }
        public T? GetById(int id)
        {
            return BaseQuery().Where(_ => _.Id == id).SingleOrDefault();
        }
        public IEnumerable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return BaseQuery().Where(predicate).ToList();
        }
        protected virtual IQueryable<T> BaseQuery()
        {
            return Context.Set<T>();
        }
    }
}
