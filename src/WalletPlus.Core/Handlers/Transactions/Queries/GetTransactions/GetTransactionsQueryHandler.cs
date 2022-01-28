using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WalletPlus.Core.Common.DTOs;
using WalletPlus.Core.Common.Interfaces.Repositories;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Core.Handlers.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQueryHandler : BaseHandler, IRequestHandler<GetTransactionsQuery, BaseResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetTransactionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(GetTransactionsQuery query, CancellationToken cancellationToken)
        {
            var page = query.Page;
            var pageSize = query.PageSize;
            var (transactions, count) = new ValueTuple<List<Transaction>, long>();

            (transactions, count) = await _unitOfWork.TransactionRepository.GetTransactionsAsync(page, pageSize);

            return HandleResponse(
                BuildTransactionsResponse(transactions, count, page, pageSize),
                ResponseStatus.OK
            );
        }

        private PaginatedResponse<TransactionDto> BuildTransactionsResponse(
            List<Transaction> transactions,
            long count,
            int page,
            int pageSize
        )
        {
            var response = new PaginatedResponse<TransactionDto>
            {
                ItemsList = new List<TransactionDto>(),
                TotalItems = count,
                PerPage = pageSize,
                CurrentPage = page,
                PreviousPage = page > 1 ? (int?) page - 1 : null,
                NextPage = page * pageSize < count ? (int?) page + 1 : null
            };

            foreach (var transaction in transactions)
            {
                response.ItemsList.Add(new TransactionDto
                {
                    Amount = transaction.Amount,
                    Reference = transaction.Reference,
                    SenderReference = transaction.SenderReference,
                    RecipientReference = transaction.RecipientReference,
                    TransactionType = transaction.TransactionType,
                    TransactionDate = transaction.DateCreated
                });
            }

            response.TotalPages = count < 2 ? 1 : (int) Math.Ceiling((decimal) count / response.PerPage);
            response.PagingCounter = pageSize * (page - 1) + 1;
            response.HasPreviousPage = response.PreviousPage.HasValue;
            response.HasNextPage = response.NextPage.HasValue;

            return response;
        }
    }
}