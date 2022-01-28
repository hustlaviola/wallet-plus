using System;

namespace WalletPlus.Core.Common
{
    public class Util
    {
        public static string GenerateCustomerReference()
        {
            return ("CM-" + GenerateRandomString()).ToUpper();
        }

        public static string GenerateTransactionReference()
        {
            return ("TX-" + GenerateRandomString()).ToUpper();
        }

        private static string GenerateRandomString()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }
    }
}