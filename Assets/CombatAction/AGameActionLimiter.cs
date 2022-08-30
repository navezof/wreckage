using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGameActionLimiter : MonoBehaviour
{
    protected CombatAction combatAction;

    protected void OnEnable()
    {
        combatAction = GetComponent<CombatAction>();

        combatAction.OnGameActionStart += OnGameActionStart;
        combatAction.OnGameActionEnd += OnGameActionEnd;
    }

    protected void OnDisable()
    {
        combatAction.OnGameActionStart -= OnGameActionStart;
        combatAction.OnGameActionEnd -= OnGameActionEnd;
    }

    protected abstract void OnGameActionStart(object sender, EventArgs e);
    protected abstract void OnGameActionEnd(object sender, EventArgs e);

    public abstract bool IsLimited();
}
