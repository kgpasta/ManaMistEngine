using ManaMist.Utility;

namespace ManaMist.Actions
{
    public class MoveAction : Action
    {
        public CanMoveFunction CanMove;

        public MoveAction(CanMoveFunction canMoveFunction) : base(ActionType.MOVE)
        {
            this.CanMove = canMoveFunction;
        }

        public delegate bool CanMoveFunction(Coordinate start, Coordinate end);
    }
}