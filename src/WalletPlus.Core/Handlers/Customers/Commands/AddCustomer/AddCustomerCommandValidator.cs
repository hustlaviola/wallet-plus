using FluentValidation;
using WalletPlus.Core.Common.Constants;

namespace WalletPlus.Core.Handlers.Customers.Commands.AddCustomer
{
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("'firstName' is required")
                .MaximumLength(100)
                .WithMessage("'firstName' cannot exceed 100 characters")
                .Matches(Regex.ALPHABET)
                .WithMessage("'firstName' can only contain alphabets");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("'lastName' is required")
                .MaximumLength(100)
                .WithMessage("'lastName' cannot exceed 100 characters")
                .Matches(Regex.ALPHABET)
                .WithMessage("'lastName' can only contain alphabets");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("'email' is required")
                .MaximumLength(200)
                .WithMessage("'email' cannot contain more than 200 characters")
                .Matches(Regex.EMAIL)
                .WithMessage("'email' must be a valid email address");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .WithMessage("'phoneNumber' is required")
                .MaximumLength(15)
                .WithMessage("'phoneNumber' cannot exceed 15 characters")
                .Matches(Regex.PHONE_NUMBER)
                .WithMessage("'phoneNumber' must be a valid Nigerian phone number");
        }
    }
}