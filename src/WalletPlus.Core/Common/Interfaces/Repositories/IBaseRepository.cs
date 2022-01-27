using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Core.Common.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
        Task AddAsync(TEntity model);
        void Update(TEntity model);
    }
}