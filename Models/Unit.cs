using ManaMist.Utility;

namespace ManaMist.Models
{
    public abstract class Unit : Entity
    {
        public int movementRange { get; set; }

        public Unit(string id, string name, Cost cost, int movementRange) : base(id, name, cost)
        {
            this.movementRange = movementRange;
        }

        public override bool CanMove(Coordinate start, Coordinate end)
        {
            return start.Distance(end) <= movementRange;
        }
    }
}