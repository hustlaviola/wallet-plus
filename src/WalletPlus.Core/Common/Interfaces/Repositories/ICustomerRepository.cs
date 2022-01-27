using System.Threading.Tasks;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Core.Common.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<bool> EmailExists(string email);
        Task<bool> PhoneNumberExists(string phoneNumber);
    }
}