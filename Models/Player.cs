using System;
using System.Collections;
using System.Collections.Generic;
using ManaMist.Controllers;
using ManaMist.Models;
using ManaMist.Utility;

public class Player
{
    public int id { get; set; }
    private List<Phase> Phases = new List<Phase>();
    private Phase CurrentPhase = Phase.WAITING;
    private int PhaseIndex = 0;
    private Dictionary<string, Entity> entities = new Dictionary<string, Entity>();
    public Entity selectedEntity { get; set; } = null;

    public Player(int id, TurnController turnController)
    {
        this.id = id;
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

    public void AddEntity(Entity entity)
    {
        entities[entity.id] = entity;
    }

    public void RemoveEntity(Entity entity)
    {
        entities.Remove(entity.id);
    }

    public Entity GetEntity(string id)
    {
        return entities.ContainsKey(id) ? entities[id] : null;
    }

    public void SelectEntity(string id)
    {
        if (entities.ContainsKey(id))
        {
            selectedEntity = entities[id];
        }
    }

}
