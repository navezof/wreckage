using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhaseBehaviour
{
    protected GamePhaseData[] updatePhaseList;

    protected PhaseBehaviour(GamePhaseData[] updatePhaseList)
    {
        this.updatePhaseList = updatePhaseList;

        GamePhaseManager.current.OnGamePhaseChanged += UpdatePhase;
    }

    public void UnsubscribeFromEvent()
    {
        GamePhaseManager.current.OnGamePhaseChanged -= UpdatePhase;
    }

    private void UpdatePhase(object sender, GamePhaseChangeEventArgs e)
    {
        foreach (GamePhaseData updatePhase in updatePhaseList)
        {
            if (updatePhase == e.currentGamePhase)
            {
                Update();
            }
        }
    }

    protected abstract void Update();
}
