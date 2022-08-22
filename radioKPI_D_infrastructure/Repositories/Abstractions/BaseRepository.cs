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
    internal class BaseRepository<T, TKey>
        where T : class, IDbEntity
        where TKey : struct, IEquatable<TKey>
    {
        protected DbContext Context { get; }

        public BaseRepository(DbContext context)
        {
            Context = context;
        }
    }
}
