using Nancy;

namespace MathHelper.Solver.Api.Modules
{
    public sealed class IntegrationModule : NancyModule
    {
        public IntegrationModule() : base("/api")
        {
            Get("/integrate",_ => "Please pass expression with parameters to integrate");
        }
    }
}