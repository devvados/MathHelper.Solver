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
using Nancy.ModelBinding;
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
            
            Post("/derivative", p =>
            {
                var request = this.Bind<EvaluateRequest>();

                return GetDerivativeAsync(request);
            });
        }

        private async Task<EvaluateResponse> GetDerivativeAsync(EvaluateRequest request)
        {
            var validationResult = this.Validate(request);
            if (!validationResult.IsValid)
            {
                await _logServiceClient.PostAsync(new LogRequest { Message = $"Failed generate derivative for {request.Expression}" });
                return new EvaluateResponse { Success = false, Errors = validationResult.FormattedErrors };
            }
            
            var derivativeEngine = new DerivativeEngine();
            var derivativeFunction = derivativeEngine.Evaluate(request.Expression);
            
            var result = new EvaluateResponse
            {
                Success = true, 
                SimpleDerivative = derivativeFunction.SimpleExpression,
                LatexDerivative = derivativeFunction.LatexExpression
            };
            await _logServiceClient.PostAsync(new LogRequest { Message = $"Generated derivative for {request.Expression}: {result.SimpleDerivative}"});

            return result;
        }
    }
}