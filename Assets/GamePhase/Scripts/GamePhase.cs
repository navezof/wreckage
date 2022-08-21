using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhase
{
    private GamePhaseData data;
    public GamePhaseData Data { get { return data; } private set {} }

    private string name = "";
    public string Name { get { return name ; } }


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
        Debug.Log("Enter game phase: " + Name);
    }

    public void Exit()
    {
        Debug.Log("Exit game phase: " + Name);
    }
}
