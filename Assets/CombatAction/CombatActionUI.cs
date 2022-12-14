using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatActionUI : MonoBehaviour, IListenToTargetingSystem
{
    [SerializeField] private TMPro.TMP_Text combatActionText;

    private CombatAction combatAction;

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (!combatAction)
            return ;
        if (combatAction.IsValid())
            combatActionText.text = "(" + combatAction.GetComponent<GameActionTriggerKeyCode>()?.KeyCode + ") " + combatAction.name;
        else
            combatActionText.text = "(" + combatAction.GetComponent<GameActionTriggerKeyCode>()?.KeyCode  + ") " + combatAction.name + " (disabled)";
    }

    public void LinkToCombatAction(CombatAction combatAction)
    {
        this.combatAction = combatAction;
        UpdateText();
    }

    public void HandleTargetingSystemChanged(GameObject first, GameObject second)
    {
        UpdateText();
    }
}
