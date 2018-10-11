using System;
using System.Collections;
using System.Collections.Generic;
using ManaMist.Controllers;
using ManaMist.Utility;

public class Player
{
    public int id;
    public List<Phase> Phases = new List<Phase>();
    public Phase CurrentPhase = Phase.WAITING;
    public int PhaseIndex = 0;

    public Player(TurnController turnController)
    {
        turnController.OnTurnStart += InitializeTurn;

        Phases.Add(Phase.ACTIVE);
    }

    private void InitializeTurn(object sender, TurnEventArgs args)
    {
        if (args.player == id && args.turnNumber != 0)
        {
            CurrentPhase = Phases[PhaseIndex];
        }
    }

    private void IncrementPhase()
    {
        PhaseIndex++;
        if (Phases.Count > PhaseIndex)
        {
            CurrentPhase = Phases[PhaseIndex];
        }
        else
        {
            PhaseIndex = 0;
            CurrentPhase = Phase.WAITING;
        }
    }

    private void DecrementPhase()
    {
        PhaseIndex--;
        if (PhaseIndex >= 0)
        {
            CurrentPhase = Phases[PhaseIndex];
        }
        else
        {
            PhaseIndex = 1;
            CurrentPhase = Phase.ACTIVE;
        }
    }

}
