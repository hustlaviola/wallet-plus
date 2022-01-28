using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WalletPlus.Core.Common.Interfaces.Repositories;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected internal readonly DbContext context;

        public BaseRepository(DbContext dbContext)
        {
            context = dbContext;
        }

        public async Task AddAsync(TEntity model)
        {
            model.DateCreated = DateTime.Now;
            await context.Set<TEntity>().AddAsync(model).ConfigureAwait(false);
        }

        public async Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking();
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (includes != null)
            {
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }
            }
            if (orderBy != null) query = orderBy(query);
            return await query.SingleOrDefaultAsync(predicate).ConfigureAwait(false);
        }

        public void Update(TEntity model)
        {
            model.DateUpdated = DateTime.Now;
            context.Update(model);
        }
    }
}