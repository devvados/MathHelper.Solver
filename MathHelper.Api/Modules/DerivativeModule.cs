using System.Reflection;
using System.Threading.Tasks;
using Logger.Api.Models;
using Logger.Api.Modules;
using MathHelper.Api.Models;
using MathHelper.Host;
using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.Validation;

namespace MathHelper.Api.Modules
{
    public sealed class DerivativeModule : NancyModule
    {   
        private ILogger<DerivativeModule> _logger;
        private readonly ServiceClient<LogRequest, LogResponse> _logServiceClient;

        public DerivativeModule(ILoggerFactory loggerFactory, ServiceClient<LogRequest, LogResponse> logServiceClient)
        {
            _logger = loggerFactory.CreateLogger<DerivativeModule>();
            _logServiceClient = logServiceClient;

            Get("/derivative/{expression:int}", p => GetDerivativeAsync(new ExpressionRequest() { Expression = p.expression }));
        }

        private async Task<ExpressionResponse> GetDerivativeAsync(ExpressionRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.Post(new LogRequest { Message = $"Failed to generate factorial for {request.Expression}" });
                return new ExpressionResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var result = new ExpressionResponse { Success = true, Derivative = request.Expression };
            await _logServiceClient.Post(new LogRequest { Message = $"Generated Factorial for {request.Expression}: {result.Derivative}"});

            return result;
        }
    }
}