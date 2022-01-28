using FluentAssertions;
using NUnit.Framework;
using WalletPlus.Core.Domain.Entities;

namespace WalletPlus.Core.UnitTests.Domain.Entities
{
    public class CustomerTests
    {
        [Test]
        public void ConstructorGeneratesCustomerReference()
        {
            var actual = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");

            actual.CustomerReference.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public void ConstructorGeneratesCustomerInstance()
        {
            var actual = new Customer("Viola", "Vino", "hustla@gmail.com", "08030537420");

            actual.FirstName.Should().BeEquivalentTo("Viola");
            actual.LastName.Should().BeEquivalentTo("Vino");
            actual.Email.Should().BeEquivalentTo("hustla@gmail.com");
            actual.PhoneNumber.Should().BeEquivalentTo("08030537420");
        }
    }
}