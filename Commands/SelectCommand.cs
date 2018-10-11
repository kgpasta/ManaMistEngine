namespace ManaMist.Commands
{
    public class SelectCommand : Command
    {
        public string id { get; set; }

        public SelectCommand(string id) : base(CommandType.SELECT)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return "Selecting " + id;
        }
    }
}