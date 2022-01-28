using FluentValidation;

namespace WalletPlus.Core.Handlers.Customers.Queries.GetWalletBalance
{
    public class GetWalletBalanceQueryValidator : AbstractValidator<GetWalletBalanceQuery>
    {
        public GetWalletBalanceQueryValidator()
        {
            RuleFor(m => m.CustomerReference)
                .NotEmpty()
                .WithMessage("'customerReference' is required")
                .MaximumLength(100)
                .WithMessage("'customerReference' cannot exceed 100 characters");
        }
    }
}