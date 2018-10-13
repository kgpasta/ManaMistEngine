using ManaMist.Utility;

namespace ManaMist.Commands
{
    public class DescribeCommand : Command
    {
        public bool describeAll { get; set; } = false;
        public string entity { get; set; }

        public Coordinate coordinate { get; set; }

        public DescribeCommand(int playerId, Coordinate coordinate) : base(playerId, CommandType.DESCRIBE)
        {
            this.coordinate = coordinate;
        }

        public DescribeCommand(int playerId, string entity) : base(playerId, CommandType.DESCRIBE)
        {
            this.entity = entity;
        }

        public DescribeCommand(int playerId) : base(playerId, CommandType.DESCRIBE)
        {
            this.describeAll = true;
        }

        public override string ToString()
        {
            string value = describeAll ? "All" : entity != null ? entity : coordinate.ToString();
            return "Describing " + value;
        }
    }
}