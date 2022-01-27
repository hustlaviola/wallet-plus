using System;

namespace WalletPlus.Core.Common.Exceptions
{
    public class BadGatewayException : Exception
    {
        public BadGatewayException() : base("Request failed from external provider") { }
        public BadGatewayException(string message) : base(message) { }
    }
}