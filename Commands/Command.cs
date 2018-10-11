namespace ManaMist.Commands
{
    public enum CommandType
    {
        DESCRIBE, SELECT, MOVE, BUILD
    }

    public abstract class Command
    {
        public CommandType type { get; set; }

        public Command(CommandType type)
        {
            this.type = type;
        }
    }
}