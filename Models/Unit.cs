namespace ManaMist.Models
{
    public abstract class Unit : Entity
    {
        public int movementRange { get; set; }

        public Unit(string name, Cost cost, int movementRange) : base(name, cost)
        {
            this.movementRange = movementRange;
        }
    }
}