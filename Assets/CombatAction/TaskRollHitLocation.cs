using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskRollHitLocation : ATask
{
    [SerializeField] private StatData hitLocationStatData;

    public override void Execute()
    {
        BodyManager bodyManager = targetingSystem.Target.GetComponent<BodyManager>();

        int roll = Random.Range(0, bodyManager.BodyPartList.Count - 1);

        combatAction.GetStat(hitLocationStatData).AddModifier(roll, 1, this, "Hit Location");

        ExecuteNextTask();
    }
}
