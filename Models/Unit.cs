namespace ManaMist.Models
{
    public abstract class Unit : Entity
    {
        public int movementRange { get; set; }

        public Unit(Cost cost, int movementRange) : base(cost)
        {
            this.movementRange = movementRange;
        }
    }
}