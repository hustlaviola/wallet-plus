using System;
using System.Threading.Tasks;

namespace WalletPlus.Core.Common.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        int Save();
        Task<int> SaveAsync();
        Task CommitAsync();
        Task RollbackAsync();
        ICustomerRepository CustomerRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        IWalletRepository WalletRepository { get; }
    }
}