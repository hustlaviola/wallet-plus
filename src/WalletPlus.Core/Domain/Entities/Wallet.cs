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

        public void Deposit(decimal amount)
        {
            Balance += amount;
            PointBalance += GetPoint(amount); 
        }

        public void Credit(decimal amount)
        {
            Balance += amount;
        }

        public void Debit(decimal amount)
        {
            Balance -= amount;
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