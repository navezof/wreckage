using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseManager : MonoBehaviour
{
    public static GamePhaseManager current;
    public event EventHandler<GamePhaseChangeEventArgs> OnGamePhaseChanged;

    [SerializeField] private GamePhaseData[] gamePhaseDataList;
    private List<GamePhase> gamePhaseList = new List<GamePhase>();

    private GamePhase currentGamePhase = null;
    public GamePhase CurrentGamePhase { get { return currentGamePhase; } private set { currentGamePhase = value; } }

    private void Awake()
    {
        current = this;

        foreach (GamePhaseData gamePhaseData in gamePhaseDataList)
        {
            gamePhaseList.Add(new GamePhase(gamePhaseData));   
        }
    }

    private void Start()
    {
        ChangeGamePhase(gamePhaseList[0].Data);
    }

    public void ChangeGamePhase(GamePhaseData gamePhaseData)
    {
        CurrentGamePhase?.Exit();

        CurrentGamePhase = GetGamePhase(gamePhaseData);

        CurrentGamePhase?.Enter();

        OnGamePhaseChanged?.Invoke(this, new GamePhaseChangeEventArgs{
            newGamePhase = CurrentGamePhase
        });
    }

    public void ChangeGamePhase()
    {
        ChangeGamePhase(CurrentGamePhase.NextPhaseData);
    }

    private GamePhase GetGamePhase(GamePhaseData data)
    {
        foreach (GamePhase gamePhase in gamePhaseList)
        {
            if (gamePhase.Data == data)
                return gamePhase;
        }
        return null;
    }
}

public class GamePhaseChangeEventArgs : EventArgs
{
    public GamePhase newGamePhase;
}