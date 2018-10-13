using ManaMist.Utility;

namespace ManaMist.Models
{
    public class Worker : Unit
    {
        public Worker() : base("Worker", new Cost(), 3)
        {
        }

        public override bool CanBuild(Coordinate currentCoordinate, Coordinate buildingCoordinate)
        {
            if (currentCoordinate.IsAdjacent(buildingCoordinate))
            {
                return true;
            }
            return false;
        }
    }
}