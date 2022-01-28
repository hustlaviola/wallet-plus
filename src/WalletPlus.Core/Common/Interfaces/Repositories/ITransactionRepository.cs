using System.Collections.Generic;
using System.Threading.Tasks;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Core.Common.Interfaces.Repositories
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        Task<(List<Transaction>, long)> GetTransactionsAsync(int page, int pageSize);
    }
}