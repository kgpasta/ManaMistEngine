using ManaMist.Utility;

namespace ManaMist.Models
{
    public abstract class Building : Entity
    {
        public int buildTurns { get; set; }

        public Building(string id, string name, Cost cost, int buildTurns) : base(id, name, cost)
        {
            this.buildTurns = buildTurns;
        }

        public override bool CanMove(Coordinate start, Coordinate end)
        {
            return false;
        }
    }
}