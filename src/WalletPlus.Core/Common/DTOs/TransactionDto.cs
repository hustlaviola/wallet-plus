using System;
using WalletPlus.Core.Domain.Enums;

namespace WalletPlus.Core.Common.DTOs
{
    public class TransactionDto
    {
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public string SenderReference { get; set; }
        public string RecipientReference { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}