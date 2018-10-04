using System;
using System.Collections;
using System.Collections.Generic;

namespace ManaMist.Controllers
{
    public class TurnController : ITurnController
    {
        private Queue<int> playerQueue;
        public int currentPlayer;
        public int turnNumber;
        public event EventHandler<TurnEventArgs> OnTurnStart;
        public event EventHandler<TurnEventArgs> OnTurnEnd;

        public TurnController()
        {
            playerQueue = new Queue<int>();

            playerQueue.Enqueue(1);
            playerQueue.Enqueue(2);
        }

        public void StartTurns()
        {
            turnNumber = 0;
            currentPlayer = playerQueue.Dequeue();
            OnTurnStart(this, new TurnEventArgs(0, currentPlayer));
        }

        public void EndTurn()
        {
            OnTurnEnd?.Invoke(this, new TurnEventArgs(turnNumber, currentPlayer));

            MoveToNextPlayer(currentPlayer);

            if (playerQueue.Count == 0)
            {
                turnNumber++;
                playerQueue.Enqueue(1);
                playerQueue.Enqueue(2);
            }

            OnTurnStart?.Invoke(this, new TurnEventArgs(turnNumber, currentPlayer));
        }

        public void MoveToNextPlayer(int lastPlayer)
        {
            if (playerQueue.Count > 0)
            {
                currentPlayer = playerQueue.Dequeue();

            }
        }
    }
}
