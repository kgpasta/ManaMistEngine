using ManaMist.Utility;

namespace ManaMist.Actions
{
    public class BuildAction : Action
    {
        public CanBuildFunction CanBuild;

        public BuildAction(CanBuildFunction canBuildFunction) : base(ActionType.BUILD)
        {
            this.CanBuild = canBuildFunction;
        }

        public delegate bool CanBuildFunction(Coordinate currentCoordinate, Coordinate buildingCoordinate);
    }
}