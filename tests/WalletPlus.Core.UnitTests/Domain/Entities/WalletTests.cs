using FluentAssertions;
using NUnit.Framework;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Core.UnitTests.Domain.Entities
{
    public class WalletTests
    {
        [Test]
        public void ConstructorGeneratesWalletInstanceWithRelevantFields()
        {
            var customer = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            customer.Id = 1;
            var actual = new Wallet(customer.Id, customer.CustomerReference);

            actual.CustomerReference.Should().NotBeNullOrWhiteSpace();
            actual.CustomerId.Should().Be(1);
            actual.Balance.Should().Be(0);
            actual.PointBalance.Should().Be(0);
        }

        [Test]
        public void DepositMethodShouldIncreaseWalletBalanceByAmount()
        {
            var customer = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            customer.Id = 1;
            var actual = new Wallet(customer.Id, customer.CustomerReference);
            
            actual.Deposit(4000M);
            actual.Deposit(2500M);

            actual.Balance.Should().Be(6500M);
        }

        [Test]
        public void DepositsBelow5kShouldNotIncreasePointBalance()
        {
            var customer = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            customer.Id = 1;
            var actual = new Wallet(customer.Id, customer.CustomerReference);
            
            actual.Deposit(4000M);
            actual.Deposit(2500M);

            actual.PointBalance.Should().Be(0);
        }

        [Test]
        public void DepositsBetween5kAnd10kShouldIncreasePointBalanceBy1PercentOfAmount()
        {
            decimal amount = 6000;
            decimal percentage = 0.01M;

            var customer = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            customer.Id = 1;
            var actual = new Wallet(customer.Id, customer.CustomerReference);
            
            actual.Deposit(amount);

            actual.PointBalance.Should().Be(amount * percentage);
        }

        [Test]
        public void DepositsBetween10k1And25kShouldIncreasePointBalanceBy2AndAHalfPercentOfAmount()
        {
            decimal amount = 15000;
            decimal percentage = 0.025M;

            var customer = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            customer.Id = 1;
            var actual = new Wallet(customer.Id, customer.CustomerReference);
            
            actual.Deposit(amount);

            actual.PointBalance.Should().Be(amount * percentage);
        }

        [Test]
        public void DepositsAbove25kShouldIncreasePointBalanceBy5PercentOfAmount()
        {
            decimal amount = 50000;
            decimal percentage = 0.05M;

            var customer = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            customer.Id = 1;
            var actual = new Wallet(customer.Id, customer.CustomerReference);
            
            actual.Deposit(amount);

            actual.PointBalance.Should().Be(amount * percentage);
        }

        [Test]
        public void PointBalanceCannotBeMoreThan5k()
        {
            decimal amount = 7500000;
            decimal cappedPointBalance = 5000;

            var customer = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");
            customer.Id = 1;
            var actual = new Wallet(customer.Id, customer.CustomerReference);
            
            actual.Deposit(amount);

            actual.PointBalance.Should().Be(cappedPointBalance);
        }
    }
}