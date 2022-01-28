using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WalletPlus.Core.Common.Interfaces.Repositories;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Infrastructure.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<(List<Transaction>, long)> GetTransactionsAsync(int page, int pageSize)
        {
            var query = context.Set<Transaction>().AsNoTracking();
            var count = await query.CountAsync();
            var transactions = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return (transactions, count);
        }
    }
}