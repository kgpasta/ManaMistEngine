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
            if (entity.CanBuild(currentCoordinate, coordinate))
            {
                mapController.AddToMap(coordinate, building);
                player.AddEntity(building);
            }
            else
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return "Bulding " + building.name + " at " + coordinate.ToString();
        }
    }
}