using FluentValidation;

namespace WalletPlus.Core.Handlers.Transactions.AddMoney
{
    public class AddMoneyCommandValidator : AbstractValidator<AddMoneyCommand>
    {
        public AddMoneyCommandValidator()
        {
            RuleFor(m => m.CustomerReference)
                .NotEmpty()
                .WithMessage("'customerReference' is required")
                .MaximumLength(100)
                .WithMessage("'customerReference' cannot exceed 100 characters");

            RuleFor(m => m.Amount)
                .NotEmpty()
                .WithMessage("'amount' is required")
                .GreaterThan(0)
                .WithMessage("'amount' must be grater than zero")
                .LessThanOrEqualTo(1000000000)
                .WithMessage("'amount' cannot exceed 100000000");
        }
    }
}