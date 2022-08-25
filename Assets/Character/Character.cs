using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private new string name;
    private int team;
    private bool hasActedThisTurn;


    public string Name { get => name; set => name = value; }
    public int Team { get => team ; set => team = value ; }
    public bool HasActedThisTurn { get => hasActedThisTurn; set => hasActedThisTurn = value; }

    private void OnEnable() 
    {
        PlayerController.current.OnDisplayCharacter += HandleDisplayOnConsole;
        GamePhaseManager.current.OnGamePhaseChanged += HandleGamePhaseChanged;
    }

    private void OnDisable() 
    {
        PlayerController.current.OnDisplayCharacter -= HandleDisplayOnConsole; 
    }

    public void HandleDisplayOnConsole(object sender, System.EventArgs e)
    {
        Debug.Log("name: " + name + " - team: " + team);
    }

    public void HandleGamePhaseChanged(object sender, GamePhaseChangeEventArgs e)
    {
        if (e.newGamePhase.Name == EGamePhaseName.STATUS_UPDATE)
            hasActedThisTurn = false;
    }
}
