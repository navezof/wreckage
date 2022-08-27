using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARequirement : MonoBehaviour, IListenToTargetingSystem
{
    public abstract void HandleTargetingSystemChanged(object sender, TargetingSystemChanged e);
    public abstract bool IsMet();
}
