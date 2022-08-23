using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhase
{
    private GamePhaseData data;
    public GamePhaseData Data { get { return data; } private set {} }

    private EGamePhaseName name;
    public EGamePhaseName Name { get { return name ; } }


    private GamePhaseData nextPhaseData;
    public GamePhaseData NextPhaseData { get { return nextPhaseData; } private set {} }

    public GamePhase(GamePhaseData data)
    {
        this.data = data;
        this.name = data.Name;
        this.nextPhaseData = data.NextPhaseData;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
}

public enum EGamePhaseName
{
    GAME_START,
    STATUS_UPDATE,
    COMBAT_ACTION
}
