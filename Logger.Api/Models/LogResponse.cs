using System.Collections.Generic;

namespace Logger.Api.Models
{
    public class LogResponse
    {
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}