using System;

namespace ManaMist.Controllers
{
    public interface ITurnController
    {
        void StartTurns();
        void EndTurn();
        void MoveToNextPlayer(int lastPlayer);
        event EventHandler<TurnEventArgs> OnTurnStart;
        event EventHandler<TurnEventArgs> OnTurnEnd;
    }

    public class TurnEventArgs : EventArgs
    {
        public TurnEventArgs(int turnNumber, int player)
        {
            this.turnNumber = turnNumber;
            this.player = player;
        }
        public int player { get; set; }
        public int turnNumber { get; set; }
    }
}