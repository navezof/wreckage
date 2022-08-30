using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    static public PlayerController current;

    private void Awake() 
    {
        current = this;    
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            NextGamePhase();
        }
    }

    void NextGamePhase()
    {
        GamePhaseManager.current.ChangeGamePhase();
    }
}
