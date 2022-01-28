namespace WalletPlus.Core.Handlers.Transactions.Commands.AddMoney
{
    public class AddMoneyCommand : MediatR.IRequest<Common.DTOs.BaseResponse>
    {
        public string CustomerReference { get; set; }
        public decimal Amount { get; set; }
    }
}