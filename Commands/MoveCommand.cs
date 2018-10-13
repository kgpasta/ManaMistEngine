using ManaMist.Controllers;
using ManaMist.Models;
using ManaMist.Players;
using ManaMist.Utility;

namespace ManaMist.Commands
{
    public class MoveCommand : Command
    {
        public Coordinate coordinate { get; set; }
        public MoveCommand(int playerId, Coordinate coordinate) : base(playerId, CommandType.MOVE)
        {
            this.coordinate = coordinate;
        }

        public bool Execute(MapController mapController, Entity entity)
        {
            Coordinate startCoordinate = mapController.GetPositionOfEntity(entity.id);
            if (entity.CanMove(startCoordinate, coordinate))
            {
                mapController.MoveEntity(coordinate, entity);
            }
            else
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return "Moving to " + coordinate.ToString();
        }
    }
}