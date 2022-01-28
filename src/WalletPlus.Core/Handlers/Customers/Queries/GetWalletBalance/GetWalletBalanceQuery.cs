namespace WalletPlus.Core.Handlers.Customers.Queries.GetWalletBalance
{
    public class GetWalletBalanceQuery : MediatR.IRequest<Common.DTOs.BaseResponse>
    {
        public string CustomerReference { get; set; }

        public GetWalletBalanceQuery(string customerReference)
        {
            CustomerReference = customerReference;
        }
    }
}