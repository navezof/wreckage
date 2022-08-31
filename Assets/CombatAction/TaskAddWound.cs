using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAddWound : ATask
{
    [SerializeField] private StatData hitLocationStatData;

    public override void Execute()
    {   
        BodyManager bodyManager = SelectorManager.current.Second.GetComponent<BodyManager>();        
        if (bodyManager == null)
            return ;

        BodyPart bodyPartWounded = bodyManager.GetBodyPart(combatAction.GetStat(hitLocationStatData).Value);
        bodyPartWounded.AddWound();
    }
}
