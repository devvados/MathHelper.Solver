using FluentValidation;
using MathHelper.Api.Models;

namespace MathHelper.Api.Validators
{
    public class ExpressionRequestValidator : AbstractValidator<ExpressionRequest>
    {
        public ExpressionRequestValidator()
        {
            RuleFor(request => request.Expression).NotEmpty();
        }
    }
}