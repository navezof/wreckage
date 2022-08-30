using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskChangePhase : ATask
{
    [SerializeField] private GamePhaseData nextPhase;

    public override void Execute()
    {
        GamePhaseManager.current.ChangeGamePhase(nextPhase);

        ExecuteNextTask();
    }
}