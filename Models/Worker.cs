using ManaMist.Actions;
using ManaMist.Utility;

namespace ManaMist.Models
{
    public class Worker : Unit
    {
        public Worker() : base("Worker", new Cost(), 3)
        {
            BuildAction buildAction = new BuildAction(CanBuild);
            this.actions.Add(ActionType.BUILD, buildAction);
        }

        public bool CanBuild(Coordinate currentCoordinate, Coordinate buildingCoordinate)
        {
            if (currentCoordinate.IsAdjacent(buildingCoordinate))
            {
                return true;
            }
            return false;
        }
    }
}