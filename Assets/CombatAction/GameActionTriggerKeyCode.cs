using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionTriggerKeyCode : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode;

    private CombatAction combatAction;

    public KeyCode KeyCode { get => keyCode; }

    private void Start() 
    {
        combatAction = GetComponent<CombatAction>();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode))
        {
            combatAction.Trigger();
        }    
    }
}
