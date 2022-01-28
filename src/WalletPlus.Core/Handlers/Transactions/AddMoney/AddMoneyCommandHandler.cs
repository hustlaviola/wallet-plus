using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WalletPlus.Core.Common.DTOs;
using WalletPlus.Core.Common.Exceptions;
using WalletPlus.Core.Common.Interfaces.Repositories;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Core.Handlers.Transactions.AddMoney
{
    public class AddMoneyCommandHandler : BaseHandler, IRequestHandler<AddMoneyCommand, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMoneyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(AddMoneyCommand command, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            var wallet = await _unitOfWork.WalletRepository.GetAsync(
                w => w.CustomerReference.Equals(command.CustomerReference));

            if (wallet == null) throw new NotFoundException("Wallet not found");

            var transaction = new Transaction(command.Amount, command.CustomerReference);

            await _unitOfWork.TransactionRepository.AddAsync(transaction);
            await _unitOfWork.SaveAsync();

            wallet.AddMoney(command.Amount);
            wallet.AddPoint(GetPoint(command.Amount));

            _unitOfWork.WalletRepository.Update(wallet);
            await _unitOfWork.SaveAsync();

            await _unitOfWork.CommitAsync();

            return HandleResponse(new WalletDto
            {
                CustomerReference = wallet.CustomerReference,
                Balance = wallet.Balance,
                PointBalance = wallet.PointBalance
            }, ResponseStatus.OK);
        }

        private decimal GetPoint(decimal amount)
        {
            if (amount < 5000M) return 0;
            if (amount <= 10000M) return amount * 0.01M;
            if (amount <= 25000M) return amount * 0.025M;
            var point = amount * 0.05M;
            if (point > 5000) return 5000;
            return point;
        }
    }
}