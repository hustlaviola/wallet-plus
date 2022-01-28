using FluentAssertions;
using NUnit.Framework;
using WalletPlus.Core.Common;

namespace WalletPlus.Core.UnitTests.Common
{
    public class UtilTests
    {
        [Test]
        public void ShouldGenerateCustomerReferenceWithCMPrefix()
        {
            var actual = Util.GenerateCustomerReference();

            actual.Substring(0, 2).Should().BeEquivalentTo("CM");
        }

        [Test]
        public void ShouldGenerateTransactionReferenceWithTXPrefix()
        {
            var actual = Util.GenerateTransactionReference();

            actual.Substring(0, 2).Should().BeEquivalentTo("TX");
        }
    }
}