using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombaActionManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject combatActionUIPrefab;

    private CombatAction[] combatActionList;

    void Start()
    {
        combatActionList = FindObjectsOfType<CombatAction>();

        foreach (CombatAction combatAction in combatActionList)
        {
            GameObject newCombatActionUI = Instantiate(combatActionUIPrefab, this.transform);            
            CombatActionUI combatActionUI = newCombatActionUI.GetComponent<CombatActionUI>();
            combatActionUI.LinkToCombatAction(combatAction);
            newCombatActionUI.name = combatAction.name + "_txt";
        }
    }
}
