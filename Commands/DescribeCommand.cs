using ManaMist.Utility;

namespace ManaMist.Commands
{
    public class DescribeCommand : Command
    {
        public bool describeAll { get; set; } = false;
        public string entity { get; set; }

        public Coordinate coordinate { get; set; }

        public DescribeCommand(Coordinate coordinate) : base(CommandType.DESCRIBE)
        {
            this.coordinate = coordinate;
        }

        public DescribeCommand(string entity) : base(CommandType.DESCRIBE)
        {
            this.entity = entity;
        }

        public DescribeCommand() : base(CommandType.DESCRIBE)
        {
            this.describeAll = true;
        }

        public override string ToString()
        {
            string inputValue = entity != null ? entity : coordinate.ToString();
            string value = describeAll ? "All" : inputValue;
            return "Describing " + value;
        }
    }
}