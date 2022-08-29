using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskRoll : ATask
{
    [SerializeField] private RollModifier[] rollModifierList;

    public override void Execute()
    {
        ETaskResolution result;
        int targetNumber = GetTargetNumber();
        int roll = Random.Range(0, 100);

        if (roll <= targetNumber)
        {   
            result = ETaskResolution.ON_SUCCESS;
        }
        else
            result = ETaskResolution.ON_FAILURE;

        Debug.Log(targetingSystem.Actor.GetComponent<CombatProfileManager>().GetName() + "> task: " + name + " Roll " + roll + " against TN " + targetNumber + " resultint in " + result);

        ExecuteNextTask(result);
    }

    public int GetTargetNumber()
    {
        int targetNumber = 0;
        foreach (RollModifier rollModifier in rollModifierList)
        {
            int value = 0;

            if (rollModifier.source.data != null && StatManager.GetSource(rollModifier.source, targetingSystem) != null)
                value += StatManager.GetSource(rollModifier.source, targetingSystem).GetStat(rollModifier.source.data).Value;

            value += rollModifier.flatValue;
            if (rollModifier.statOperator == EStatOperator.ADD)
                targetNumber += value;
            else
                targetNumber -= value;
        }

        return Mathf.Clamp(targetNumber, 0, 100);        
    }
}

[System.Serializable]
public struct RollModifier
{
    public StatSource source;
    public int flatValue;
    public EStatOperator statOperator;
}


public enum ETargetNumberModifierSource
{
    ACTOR,
    ACTOR_GEAR,
    TARGET,
    TARGET_GEAR
}

public enum EStatOperator
{
    ADD,
    REMOVE
}