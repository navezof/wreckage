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
    public event EventHandler OnDisplayBody;

    private void Awake() 
    {
        current = this;    
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
        if (Input.GetKeyDown("d"))
        {
            OnDisplayBody?.Invoke(this, null);
        }
    }

    void TEST_GamePhaseChange()
    {
        GamePhaseManager.current.ChangeGamePhase();
    }
}
