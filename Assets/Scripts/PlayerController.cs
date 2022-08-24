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
    public event EventHandler OnAddWound;
    public event EventHandler OnRemoveWound;
    public event EventHandler OnDisplayConditions;

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
            OnDisplayCharacter?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown("c"))
        {
            OnDisplayStats?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown("d"))
        {
            OnDisplayBody?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("OnAddWound");
            OnAddWound?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown("f"))
        {
            Debug.Log("OnRemoveWound");
            OnRemoveWound?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyDown("g"))
        {
            Debug.Log("OnDisplayConditions");
            OnDisplayConditions?.Invoke(this, EventArgs.Empty);
        }
    }

    void TEST_GamePhaseChange()
    {
        GamePhaseManager.current.ChangeGamePhase();
    }
}
