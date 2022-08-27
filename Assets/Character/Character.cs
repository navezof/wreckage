using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IStatable
{
    private StatManager statManager;
    private new string name;
    private int team;
    private bool hasActedThisTurn;

    public string Name { get => name; set => name = value; }
    public int Team { get => team ; set => team = value ; }
    public bool HasActedThisTurn { get => hasActedThisTurn; set => hasActedThisTurn = value; }

    private void OnEnable() 
    {
        GamePhaseManager.current.OnGamePhaseChanged += HandleGamePhaseChanged;
    }

    private void OnDisable() 
    {
        GamePhaseManager.current.OnGamePhaseChanged -= HandleGamePhaseChanged;
    }

    public void HandleGamePhaseChanged(object sender, GamePhaseChangeEventArgs e)
    {
        if (e.newGamePhase.Name == EGamePhaseName.STATUS_UPDATE)
            hasActedThisTurn = false;
    }

    public Stat GetStat(StatData data)
    {
        if (statManager == null)
            statManager = GetComponent<StatManager>();
        return statManager.GetStat(data);
    }
}
