namespace WalletPlus.Core.Handlers.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQuery : MediatR.IRequest<Common.DTOs.BaseResponse>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetTransactionsQuery(int page, int pageSize)
        {
            Page = page > 0 ? page : 1;
            PageSize = pageSize > 0 ? pageSize : 20;
        }
    }
}