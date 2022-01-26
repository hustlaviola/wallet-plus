namespace WalletPlus.Core.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public long SenderId { get; private set; }
        public long RecipientId { get; private set; }
        public decimal Amount { get; private set; }
        public Customer Sender { get; set; }
        public Customer Recipient { get; set; }
    }
}