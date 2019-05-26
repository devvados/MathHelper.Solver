using System.Collections.Generic;

namespace MathHelper.Api.Contracts.Logger
{
    public class LogResponse
    {
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}