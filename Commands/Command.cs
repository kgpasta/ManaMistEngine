using ManaMist.Controllers;
using ManaMist.Players;

namespace ManaMist.Commands
{
    public enum CommandType
    {
        DESCRIBE, SELECT, MOVE, BUILD
    }

    public abstract class Command
    {
        public CommandType type { get; set; }

        public int playerId { get; set; }

        public Command(int playerId, CommandType type)
        {
            this.type = type;
            this.playerId = playerId;
        }
    }
}