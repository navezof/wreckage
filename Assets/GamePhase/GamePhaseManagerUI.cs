using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseManagerUI : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text gamePhaseText;
    
    private void OnEnable()
    {
        GamePhaseManager.current.OnGamePhaseChanged += HandleOnGamePhaseChanged;
    }

    private void OnDisable()
    {
        GamePhaseManager.current.OnGamePhaseChanged -= HandleOnGamePhaseChanged;    
    }

    private void HandleOnGamePhaseChanged(object sender, GamePhaseChangeEventArgs e)
    {
        gamePhaseText.text = e.newGamePhase.Name.ToString();
    }

}
