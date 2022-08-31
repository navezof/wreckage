using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAddStatModifier : ATask
{
    [SerializeField] private StatSource sourceStat;
    [SerializeField] private RollModifier[] rollModifierList;

    public override void Execute()
    {
        Stat statToModify = StatManager.GetSource(sourceStat, selectorManager).GetStat(sourceStat.data);

        int modifierTotalValue = 0;
        foreach (RollModifier rollModifier in rollModifierList)
        {
            int modifier = 0;
            if (rollModifier.source.data != null)
                modifier += StatManager.GetSource(rollModifier.source, selectorManager).GetStat(rollModifier.source.data).Value;
            modifier += rollModifier.flatValue;

            if (rollModifier.statOperator == EStatOperator.ADD)
                modifierTotalValue += modifier;
            else
                modifierTotalValue -= modifier;
        }

        statToModify.AddModifier(modifierTotalValue, 1, this, combatAction.Name);

        ExecuteNextTask();
    }
}