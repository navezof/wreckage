using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    public static TargetingSystem current;

    [SerializeField] private CharacterManager characterManager;

    private GameObject actor = null;
    private GameObject target = null;

    public event EventHandler<TargetingSystemChanged> OnTargetingSystemChanged;

    public GameObject Target { get => target; set => target = value; }
    public GameObject Actor { get => actor; set => actor = value; }

    void Start()
    {
        current = this;

        actor = null;
        target = null;

        OnTargetingSystemChanged?.Invoke(this, new TargetingSystemChanged
        {
            actor = this.actor,
            target = this.target
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            SelectCharacter(0);
        if (Input.GetKeyDown(KeyCode.I))
            SelectCharacter(1);
        if (Input.GetKeyDown(KeyCode.O))
            SelectCharacter(2);
        if (Input.GetKeyDown(KeyCode.P))
            SelectCharacter(3);
    }

    void SelectCharacter(int index)
    {
        if (actor != null && target != null)
        {
            actor = null;
            target = null;
        }

        if (actor == null)
        {
            if (!characterManager.GetCharacter(0, index).GetComponent<CombatProfileManager>().GetHasActedThisTurn())
                actor = characterManager.GetCharacter(0, index);
        }
        else
        {
            target = characterManager.GetCharacter(1, index);
        }

        OnTargetingSystemChanged?.Invoke(this, new TargetingSystemChanged
        {
            actor = this.actor,
            target = this.target
        });
    }
}

public class TargetingSystemChanged : EventArgs
{
    public GameObject actor;
    public GameObject target;
}
