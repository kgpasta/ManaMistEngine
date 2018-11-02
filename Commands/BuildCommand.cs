using ManaMist.Actions;
using ManaMist.Controllers;
using ManaMist.Models;
using ManaMist.Players;
using ManaMist.Utility;

namespace ManaMist.Commands
{
    public class BuildCommand : Command
    {
        public Coordinate coordinate { get; set; }
        public Building building { get; set; }

        public BuildCommand(int playerId, Coordinate coordinate, Building building) : base(playerId, CommandType.BUILD)
        {
            this.building = building;
            this.coordinate = coordinate;
        }

        public bool Execute(MapController mapController, Player player, Entity entity)
        {
            Coordinate currentCoordinate = mapController.GetPositionOfEntity(entity.id);

            Action action = entity.GetAction(ActionType.BUILD);

            if (action != null)
            {
                BuildAction buildAction = (BuildAction)action;
                if (buildAction.CanBuild(currentCoordinate, coordinate))
                {
                    mapController.AddToMap(coordinate, building);
                    player.AddEntity(building);
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return "Bulding " + building.name + " at " + coordinate.ToString();
        }
    }
}