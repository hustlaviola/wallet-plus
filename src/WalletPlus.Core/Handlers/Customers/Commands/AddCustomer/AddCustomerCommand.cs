namespace WalletPlus.Core.Handlers.Customers.Commands.AddCustomer
{
    public class AddCustomerCommand : MediatR.IRequest<Common.DTOs.BaseResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}