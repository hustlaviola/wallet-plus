using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WalletPlus.Core.Common.DTOs;
using WalletPlus.Core.Common.Exceptions;
using WalletPlus.Core.Common.Interfaces.Repositories;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Core.Handlers.Transactions.SendMoney
{
    public class SendMoneyCommandHandler : BaseHandler, IRequestHandler<SendMoneyCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SendMoneyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(SendMoneyCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var senderWallet = await _unitOfWork.WalletRepository.GetAsync(
                w => w.CustomerReference.Equals(command.SenderReference));

            if (senderWallet == null) throw new NotFoundException("Sender wallet not found");

            var amount = command.Amount;

            if (senderWallet.Balance < amount)
                throw new ValidationException("Insufficient funds");

            await DebitWallet(senderWallet, amount);

            var recipientWallet = await _unitOfWork.WalletRepository.GetAsync(
                w => w.CustomerReference.Equals(command.RecipientReference));

            if (recipientWallet == null)
            {
                await _unitOfWork.RollbackAsync();
                throw new NotFoundException("Sender wallet not found");
            }

            await CreditWallet(recipientWallet, amount);

            var transaction = await AddTransaction(amount, command.SenderReference, command.RecipientReference);

            await _unitOfWork.CommitAsync();

            return HandleResponse(GetTransactionResponse(transaction), ResponseStatus.OK);
        }

        private async Task CreditWallet(Wallet wallet, decimal amount)
        {
            wallet.AddMoney(amount);

            _unitOfWork.WalletRepository.Update(wallet);
            await _unitOfWork.SaveAsync();
        }

        private async Task DebitWallet(Wallet wallet, decimal amount)
        {
            wallet.Debit(amount);

            _unitOfWork.WalletRepository.Update(wallet);
            await _unitOfWork.SaveAsync();
        }

        private async Task<Transaction> AddTransaction(decimal amount, string sender, string recipient)
        {
            var transaction = new Transaction(amount, sender, recipient);

            await _unitOfWork.TransactionRepository.AddAsync(transaction);
            await _unitOfWork.SaveAsync();

            return transaction;
        }

        private TransactionDto GetTransactionResponse(Transaction transaction)
        {
            return new TransactionDto
            {
                Amount = transaction.Amount,
                Reference = transaction.Reference,
                SenderReference = transaction.SenderReference,
                RecipientReference = transaction.RecipientReference,
                TransactionType = transaction.TransactionType,
                TransactionDate = transaction.DateCreated,
            };
        }
    }
}