using Nancy;

namespace MathHelper.Api.Modules
{
    public sealed class DerivativeModule : NancyModule
    {
        public DerivativeModule()
        {
            Get("/",_ => "Please select action");
        }
    }
}