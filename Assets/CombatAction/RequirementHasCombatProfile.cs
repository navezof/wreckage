using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementHasCombatProfile : ARequirement
{
    [SerializeField] private int teamIndex;

    public override bool IsMet()
    {
        if (SelectorManager.current.Second == null)
            return false;

        CombatProfileManager combatProfileManager = SelectorManager.current.Second.GetComponent<CombatProfileManager>();

        if (combatProfileManager == null ||
        combatProfileManager.CombatProfile == null ||
        combatProfileManager.CombatProfile.Team != teamIndex)
        {
            return false;
        }
        return true;
    }
}
