using System.Reflection;
using System.Threading.Tasks;
using Logger.Api.Models;
using Logger.Api.Modules;
using MathHelper.Api.Models;
using MathHelper.Host;
using MathLib.Engine;
using MathLib.Engine.Modules;
using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.Extensions;
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

            Get("/derivative/{value:expression}", p => GetDerivativeAsync(new ExpressionRequest()
            {
                Expression =  p.value
            }));
        }

        private async Task<ExpressionResponse> GetDerivativeAsync(ExpressionRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed to generate factorial for {request.Expression}" });
                return new ExpressionResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            var derivativeEngine = new DerivativeEngine();
            var derivativeFunction = derivativeEngine.Evaluate(request.Expression);
            
            var result = new ExpressionResponse
            {
                Success = true, 
                SimpleDerivative = derivativeFunction.SimpleExpression,
                LatexDerivative = derivativeFunction.LatexExpression
            };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Generated Factorial for {request.Expression}: {result.SimpleDerivative}"});

            return result;
        }
    }
}