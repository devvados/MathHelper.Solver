using Logger.Api.Models;
using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Validation;

namespace Logger.Api.Modules
{
    public sealed class LoggerModule : NancyModule
    {
        private ILogger<LoggerModule> _logger;

        public LoggerModule(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LoggerModule>();

            Post("/log", p => PostLogRequest());
        }

        LogResponse PostLogRequest()
        {
            var request = this.Bind<LogRequest>();
            var validationResult = this.Validate(request);

            if (!validationResult.IsValid)
            {
                _logger.LogInformation($"Failed to log message '{request.Message}'");
                return new LogResponse { Success = false, Errors = validationResult.FormattedErrors };
            }

            _logger.LogInformation($"Logging Message: '{request.Message}'");

            return new LogResponse { Success = true };
        }

    }
}