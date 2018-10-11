namespace ManaMist.Models
{
    public class Worker : Unit
    {
        public Worker(string id) : base(id, "Worker", new Cost(), 3)
        {
        }
    }
}