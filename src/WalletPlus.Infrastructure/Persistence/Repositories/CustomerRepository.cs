using Microsoft.EntityFrameworkCore;
using WalletPlus.Core.Common.Interfaces.Repositories;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
    }
}