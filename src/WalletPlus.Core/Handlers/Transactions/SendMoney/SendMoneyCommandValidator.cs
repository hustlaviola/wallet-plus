using FluentValidation;

namespace WalletPlus.Core.Handlers.Transactions.SendMoney
{
    public class SendMoneyCommandValidator : AbstractValidator<SendMoneyCommand>
    {
        public SendMoneyCommandValidator()
        {
            RuleFor(m => m.Amount)
                .NotEmpty()
                .WithMessage("'amount' is required")
                .GreaterThan(0)
                .WithMessage("'amount' must be greater than 0")
                .LessThanOrEqualTo(1000000000)
                .WithMessage("'amount' cannot exceed 100000000");

            RuleFor(m => m.SenderReference)
                .NotEmpty()
                .WithMessage("'senderReference' is required")
                .MaximumLength(100)
                .WithMessage("'senderReference' cannot exceed 100 characters");

            RuleFor(m => m.RecipientReference)
                .NotEmpty()
                .WithMessage("'recipientReference' is required")
                .MaximumLength(100)
                .WithMessage("'recipientReference' cannot exceed 100 characters");
        }
    }
}