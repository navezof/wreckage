using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementHasGear : ARequirement
{
    [SerializeField] GearData gearToHave;

    public override bool IsMet()
    {
        GearManager gearManager = SelectorManager.current.First.GetComponent<GearManager>();

        if (gearManager == null)
            return false;
            
        Gear gear = gearManager.GetGear(gearToHave);
        if (gear != null)
            return true;
        return false;
    }
}
