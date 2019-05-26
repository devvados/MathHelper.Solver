using Nancy.Routing.Constraints;

namespace MathHelper.Solver.Api.RouteSegmentConstraints
{
    public class EmailRouteSegmentConstraint : RouteSegmentConstraintBase<string>
    {
        public override string Name => "expression";

        protected override bool TryMatch(string constraint, string segment, out string matchedValue)
        {
            matchedValue = segment;
            return true;
        }
    }
}