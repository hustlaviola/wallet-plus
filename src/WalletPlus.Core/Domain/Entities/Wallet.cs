namespace WalletPlus.Core.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public long CustomerId { get; private set; }
        public decimal Balance { get; private set; }
        public decimal PointBalance { get; private set; }
        public Customer Customer { get; set; }
    }
}