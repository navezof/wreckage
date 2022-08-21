using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
    }

    void TEST_ReceivingGamePhaseChangeEvent(object sender, GamePhaseChangeEventArgs e)
    {
        if (e.newGamePhase == null)
            Debug.Log("1");
        Debug.Log("Received event: Gamephase change to " + e.newGamePhase.Name);
    }

    void TEST_GamePhaseChange()
    {
        Debug.Log("TEST_GamePhaseChange");
        GamePhaseManager.current.ChangeGamePhase();
    }
}
