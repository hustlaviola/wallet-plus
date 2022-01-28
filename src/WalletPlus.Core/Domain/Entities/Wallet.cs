namespace WalletPlus.Core.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public long CustomerId { get; private set; }
        public string CustomerReference { get; private set; }
        public decimal Balance { get; private set; }
        public decimal PointBalance { get; private set; }
        public Customer Customer { get; set; }

        public Wallet(long customerId, string customerReference)
        {
            CustomerId = customerId;
            CustomerReference = customerReference;
            Balance = 0;
            PointBalance = 0;
        }

        public void AddMoney(decimal amount)
        {
            Balance += amount;
        }

        public void AddPoint(decimal points)
        {
            PointBalance += points;
        }

        public void Debit(decimal amount)
        {
            Balance -= amount;
        }
    }
}