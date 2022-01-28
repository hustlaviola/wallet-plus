using WalletPlus.Core.Common;
using WalletPlus.Core.Domain.Enums;

namespace WalletPlus.Core.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; private set; }
        public string Reference { get; private set; }
        public string SenderReference { get; private set; }
        public string RecipientReference { get; private set; }
        public TransactionType TransactionType { get; private set; }

        public Transaction(decimal amount, string sender)
        {
            Amount = amount;
            Reference = Util.GenerateTransactionReference();
            SenderReference = sender;
            TransactionType = TransactionType.DEPOSIT;
        }

        public Transaction(decimal amount, string sender, string recipient)
        {
            Amount = amount;
            Reference = Util.GenerateTransactionReference();
            SenderReference = sender;
            RecipientReference = recipient;
            TransactionType = TransactionType.TRANSFER;
        }
    }
}