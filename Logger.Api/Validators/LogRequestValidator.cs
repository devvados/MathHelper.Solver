using FluentValidation;
using Logger.Api.Models;

namespace Logger.Api.Validators
{
    public class LogRequestValidator : AbstractValidator<LogRequest>
    {
        public LogRequestValidator()
        {
            RuleFor(request => request.Message).NotEmpty();
        }
    }
}