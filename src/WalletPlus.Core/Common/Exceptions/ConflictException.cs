using System;

namespace WalletPlus.Core.Common.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException() : base() { }

        public ConflictException(string message) : base(message) { }

        public ConflictException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ConflictException(string name, object key)
            : base($"Entity \"{name}\" ({key}) is in use.")
        {
        }
    }
}