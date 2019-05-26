using FluentValidation;
using MathHelper.Solver.Api.Contracts.Client;

namespace MathHelper.Solver.Api.Validators
{
    public class ExpressionRequestValidator : AbstractValidator<EvaluateRequest>
    {
        public ExpressionRequestValidator()
        {
            RuleFor(request => request.Expression).NotEmpty();
        }
    }
}