using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementHasBody : ARequirement
{
    public override bool IsMet()
    {
        BodyManager gearManager = SelectorManager.current.First.GetComponent<BodyManager>();
            
        if (gearManager != null)
            return true;
        return false;
    }
}
