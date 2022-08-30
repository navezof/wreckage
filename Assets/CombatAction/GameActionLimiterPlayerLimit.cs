using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionLimiterPlayerLimit : AGameActionLimiter
{
    private bool playerActed = false;

    private new void OnEnable() 
    {
        base.OnEnable();
        playerActed = false;
    }

    protected override void OnGameActionStart(object sender, EventArgs e)
    {
        ;
    }

    protected override void OnGameActionEnd(object sender, EventArgs e)
    {
        playerActed = true;
    }

    public override bool IsLimited()
    {
        if (playerActed)
            return true;
        return false;
    }
}
