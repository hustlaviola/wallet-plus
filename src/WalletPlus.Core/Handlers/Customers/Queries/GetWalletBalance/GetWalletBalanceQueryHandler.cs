using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WalletPlus.Core.Common.DTOs;
using WalletPlus.Core.Common.Exceptions;
using WalletPlus.Core.Common.Interfaces.Repositories;

namespace WalletPlus.Core.Handlers.Customers.Queries.GetWalletBalance
{
    public class GetWalletBalanceQueryHandler : BaseHandler, IRequestHandler<GetWalletBalanceQuery, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWalletBalanceQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(GetWalletBalanceQuery query, CancellationToken cancellationToken)
        {
            var wallet = await _unitOfWork.WalletRepository.GetAsync(
                w => w.CustomerReference.Equals(query.CustomerReference));

            if (wallet == null) throw new NotFoundException("Wallet not found");

            return HandleResponse(new WalletDto
            {
                CustomerReference = wallet.CustomerReference,
                Balance = wallet.Balance,
                PointBalance = wallet.PointBalance
            }, ResponseStatus.OK);
        }
    }
}