using Microsoft.EntityFrameworkCore;
using WalletPlus.Core.Common.Interfaces.Repositories;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Infrastructure.Persistence.Repositories
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}