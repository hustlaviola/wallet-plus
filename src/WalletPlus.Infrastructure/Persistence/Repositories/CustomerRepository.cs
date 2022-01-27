using System;
using System.Threading.Tasks;
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

        public async Task<bool> EmailExists(string email)
        {
            return (await context.Set<Customer>().SingleOrDefaultAsync(
                c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase))) != null;
        }

        public async Task<bool> PhoneNumberExists(string phoneNumber)
        {
            return (await context.Set<Customer>().SingleOrDefaultAsync(
                c => c.PhoneNumber.Equals(phoneNumber, StringComparison.OrdinalIgnoreCase))) != null;
        }
    }
}