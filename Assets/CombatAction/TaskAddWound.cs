using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAddWound : ATask
{
    [SerializeField] private StatData hitLocationStatData;

    public override void Execute()
    {
        BodyManager bodyManager = targetingSystem.Target.GetComponent<BodyManager>();
        BodyPart bodyPartWounded = bodyManager.GetBodyPart(combatAction.GetStat(hitLocationStatData).Value);
        bodyPartWounded.AddWound();
    }
}
