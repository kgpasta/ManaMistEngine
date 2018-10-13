using ManaMist.Utility;

namespace ManaMist.Models
{
    public abstract class Building : Entity
    {
        public int buildTurns { get; set; }

        public Building(string name, Cost cost, int buildTurns) : base(name, cost)
        {
            this.buildTurns = buildTurns;
        }

        public override bool CanMove(Coordinate start, Coordinate end)
        {
            return false;
        }

        public override bool CanBuild(Coordinate currentCoordinate, Coordinate buildingCoordinate)
        {
            return false;
        }
    }
}