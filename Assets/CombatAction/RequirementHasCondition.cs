using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementHasCondition : ARequirement
{
    [SerializeField] ConditionData conditionToHave;
    [SerializeField] bool falseCase;

    private ConditionManager conditionManager;

    public override bool IsMet()
    {
        UpdateConditionManager();

        if (conditionManager == null)
            return false;

        Condition condition = conditionManager.GetCondition(conditionToHave);
        if (condition?.Active != falseCase)
            return true;
        return false;
    }

    private void UpdateConditionManager()
    {
        conditionManager = TargetingSystem.current.Actor?.GetComponent<ConditionManager>();
    }

    public override void HandleTargetingSystemChanged(object sender, TargetingSystemChanged e)
    {        
        conditionManager = e.actor.GetComponent<ConditionManager>();
    }
}
