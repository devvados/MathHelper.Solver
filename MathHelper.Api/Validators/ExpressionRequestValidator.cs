using FluentValidation;
using MathHelper.Api.Models;

namespace MathHelper.Api.Validators
{
    public class ExpressionRequestValidator : AbstractValidator<EvaluateRequest>
    {
        public ExpressionRequestValidator()
        {
            RuleFor(request => request.Expression).NotEmpty();
        }
    }
}