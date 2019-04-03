using System.Collections.Generic;

namespace MathHelper.Api.Models
{
    public class ExpressionResponse
    {
        public string LatexDerivative { get; set; }
        public string SimpleDerivative { get; set; }
        public bool Success { get; set; }
        public IEnumerable<dynamic> Errors { get; set; }
    }
}