using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    static public PlayerController current;
    public event EventHandler OnDisplayCharacter;
    public event EventHandler OnDisplayStats;



    private void Awake() 
    {
        current = this;    
    }

    private void OnEnable()
    {
        GamePhaseManager.current.OnGamePhaseChanged += TEST_ReceivingGamePhaseChangeEvent;
    }

    private void OnDisable()
    {
        GamePhaseManager.current.OnGamePhaseChanged -= TEST_ReceivingGamePhaseChangeEvent;
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            TEST_GamePhaseChange();
        }
        if (Input.GetKeyDown("b"))
        {
            OnDisplayCharacter?.Invoke(this, null);
        }
        if (Input.GetKeyDown("c"))
        {
            OnDisplayStats?.Invoke(this, null);
        }
    }

    void TEST_ReceivingGamePhaseChangeEvent(object sender, GamePhaseChangeEventArgs e)
    {
        Debug.Log("Received event: Gamephase change to " + e.newGamePhase.Name);
    }

    void TEST_GamePhaseChange()
    {
        Debug.Log("TEST_GamePhaseChange");
        GamePhaseManager.current.ChangeGamePhase();
    }
}
