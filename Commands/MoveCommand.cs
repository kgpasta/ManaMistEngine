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
    }
}