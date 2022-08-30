using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionLimiterCharacterLimit : AGameActionLimiter
{
    [SerializeField] private int numberOfActionPerActor = 1;
    private List<ActionPerActor> actionPerActorList = new List<ActionPerActor>();


    protected new void OnEnable()
    {
        base.OnEnable();

        actionPerActorList.Clear();
    }

    public override bool IsLimited()
    {
        if (ActorIsLimited(TargetingSystem.current.Actor))
        {
            return false;
        }
        return true;
    }

    protected override void OnGameActionStart(object sender, EventArgs e)
    {
        ;
    }

    protected override void OnGameActionEnd(object sender, EventArgs e)
    {
        UpdateActionPerActorList(TargetingSystem.current.Actor);
    }

    private bool ActorIsLimited(GameObject actor)
    {
        foreach (ActionPerActor actionPerActor in actionPerActorList)
        {
            if (actionPerActor.actor == actor)
            {
                if (actionPerActor.actionThisTurn >= numberOfActionPerActor)
                    return false;
            }
        }
        return true;
    }

    private void UpdateActionPerActorList(GameObject actor)
    {
        ActionPerActor actionPerActorFound;
        bool actorFound = false;

        foreach (ActionPerActor actionPerActor in actionPerActorList)
        {
            if (actionPerActor.actor == actor)
            {
                actionPerActorFound = actionPerActor;
                actorFound = true;
            }
        }

        if (actorFound == false)
        {
            actionPerActorList.Add(new ActionPerActor(actor, 1));
        }
    }
}

public struct ActionPerActor
{
    public ActionPerActor(GameObject actor, int actionThisTurn)
    {
        this.actor = actor;
        this.actionThisTurn = actionThisTurn;
    }

    public GameObject actor;
    public int actionThisTurn;
}
