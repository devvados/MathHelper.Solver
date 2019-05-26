using System.Collections.Generic;
using Newtonsoft.Json;

namespace MathHelper.Solver.Api.Contracts.Client
{
    public class EvaluateResponse
    {
        [JsonProperty("latexDerivative")]
        public string LatexDerivative { get; set; }
        
        [JsonProperty("simpleDerivative")]
        public string SimpleDerivative { get; set; }
        
        [JsonProperty("success")]
        public bool Success { get; set; }
        
        [JsonProperty("errors")]
        public IEnumerable<dynamic> Errors { get; set; }
    }
}