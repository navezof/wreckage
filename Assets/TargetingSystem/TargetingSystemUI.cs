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

        UpdateInstruction(null, null);
    }

    private void OnDisable()
    {
        targetingSystem.OnTargetingSystemChanged -= HandleTargetingSystemChanged;
    }

    private void HandleTargetingSystemChanged(object sender, TargetingSystemChanged e)
    {
        UpdateInstruction(e.actor?.GetComponent<CombatProfileManager>().CombatProfile, e.target?.GetComponent<CombatProfileManager>().CombatProfile);
    }

    private void UpdateInstruction(CombatProfile actor, CombatProfile target)
    {
        actorText.text = "Actor: " + actor?.Name;
        targetText.text = "Target: " + target?.Name;

        if (actor == null)
        {
            instructionText.text = "Select an actor";
        }
        else
        {
            instructionText.text = "Select a target";
        }
    }
}
