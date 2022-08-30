using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementIsGamePhase : ARequirement
{
    [SerializeField] private GamePhaseData gamePhaseData;

    public override bool IsMet()
    {
        if (GamePhaseManager.current.CurrentGamePhase.Data != gamePhaseData)
            return false;
        return true;
    }

    public override void HandleTargetingSystemChanged(object sender, TargetingSystemChanged e)
    {
        return ;
    }
}
