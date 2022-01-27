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
    }
}