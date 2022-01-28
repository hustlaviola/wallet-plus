using FluentAssertions;
using NUnit.Framework;
using WalletPlus.Core.Domain.Entities;
using WalletPlus.Core.Domain.Enums;

namespace WalletPlus.Core.UnitTests.Domain.Entities
{
    public class TransactionTests
    {
        [Test]
        public void DefaultConstructorCreatesNullReference()
        {
            var actual = new Transaction();

            actual.Reference.Should().BeNull();
        }

        [Test]
        public void ConstructorWithAmountAndSenderParametersGeneratesDepositTransactionType()
        {
            var customer = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            var actual = new Transaction(7000, customer.CustomerReference);

            actual.TransactionType.Should().BeEquivalentTo(TransactionType.DEPOSIT);
        }

        [Test]
        public void ConstructorWithAmountSenderAndRecipientParametersGeneratesTransferTransactionType()
        {
            var sender = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            var recipient = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            var actual = new Transaction(7000, sender.CustomerReference, recipient.CustomerReference);

            actual.TransactionType.Should().BeEquivalentTo(TransactionType.TRANSFER);
        }

        [Test]
        public void ConstructorGeneratesTransactionInstanceWithRelevantFields()
        {
            var sender = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            var recipient = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            var actual = new Transaction(7000, sender.CustomerReference, recipient.CustomerReference);

            actual.Amount.Should().BeApproximately(7000M, 0M);
            actual.Reference.Should().NotBeNullOrWhiteSpace();
            actual.SenderReference.Should().BeEquivalentTo(sender.CustomerReference);
            actual.RecipientReference.Should().BeEquivalentTo(recipient.CustomerReference);
            actual.TransactionType.Should().BeOfType(typeof(TransactionType));
        }
    }
}