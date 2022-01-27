namespace WalletPlus.Core.Common.Constants
{
    public class Regex
    {
        public const string PHONE_NUMBER = @"(^[0]\d{10}$)|(^[\+]?((234)|(2340))\d{10}$)";
        public const string ALPHANUMERIC = @"^[A-Za-z0-9\-_\s]+$";
        public const string ALPHABET = @"^[A-Za-z]+$";
        public const string DIGIT = @"^[0-9]+$";
        public const string EMAIL = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
    }
}