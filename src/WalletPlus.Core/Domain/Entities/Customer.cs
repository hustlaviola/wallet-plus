using WalletPlus.Core.Common;

namespace WalletPlus.Core.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string CustomerReference { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public Customer(
            string firstName,
            string lastName,
            string email,
            string phoneNumber
        )
        {
            CustomerReference = Util.GenerateCustomerReference();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}