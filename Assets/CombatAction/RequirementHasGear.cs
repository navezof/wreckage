using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementHasGear : ARequirement
{
    [SerializeField] GearData gearToHave;
    private GearManager gearManager;

    public override void HandleTargetingSystemChanged(object sender, TargetingSystemChanged e)
    {
        gearManager = e.actor.GetComponent<GearManager>();
    }

    public override bool IsMet()
    {
        Gear gear = gearManager.GetGear(gearToHave);
        if (gear != null)
            return true;
        return false;
    }
}
