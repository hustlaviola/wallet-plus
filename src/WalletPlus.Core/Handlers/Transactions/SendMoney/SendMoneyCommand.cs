namespace WalletPlus.Core.Handlers.Transactions.SendMoney
{
    public class SendMoneyCommand : MediatR.IRequest<Common.DTOs.BaseResponse>
    {
        public string SenderReference { get; set; }
        public string RecipientReference { get; set; }
        public decimal Amount { get; set; }
    }
}