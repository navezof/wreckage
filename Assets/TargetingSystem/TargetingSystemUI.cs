using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystemUI : MonoBehaviour
{
    [SerializeField] private TargetingSystem targetingSystem;

    [SerializeField] private TMPro.TMP_Text instructionText;
    [SerializeField] private TMPro.TMP_Text actorText;
    [SerializeField] private TMPro.TMP_Text targetText;


    private void OnEnable()
    {
        targetingSystem.OnTargetingSystemChanged += HandleTargetingSystemChanged;
        GamePhaseManager.current.OnGamePhaseChanged += HandleGamePhaseChanged;
    }

    private void OnDisable()
    {
        targetingSystem.OnTargetingSystemChanged -= HandleTargetingSystemChanged;
        GamePhaseManager.current.OnGamePhaseChanged -= HandleGamePhaseChanged;
    }

    private void Start()
    {
        SetActive(false);
    }

    private void SetActive(bool active)
    {
        this.transform.GetChild(0).gameObject.SetActive(active);        
    }

    private void HandleGamePhaseChanged(object sender, GamePhaseChangeEventArgs e)
    {
        if (e.newGamePhase.Name == EGamePhaseName.COMBAT_ACTION)
            SetActive(true);
        else
            SetActive(false);
    }

    private void HandleTargetingSystemChanged(object sender, TargetingSystemChanged e)
    {
        actorText.text = "Actor: " + e.actor?.Name;
        targetText.text = "Target: " + e.target?.Name; ;

        if (e.actor == null)
        {
            instructionText.text = "Select an actor";
        }
        else
        {
            instructionText.text = "Select a target";
        }
    }
}
