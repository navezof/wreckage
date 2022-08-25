using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    private CharacterManager characterManager;

    private Character actor = null;
    private Character target = null;
    private bool active = false;

    public event EventHandler<TargetingSystemChanged> OnTargetingSystemChanged;

    public Character Target { get => target; set => target = value; }
    public Character Actor { get => actor; set => actor = value; }


    private void OnEnable()
    {
        GamePhaseManager.current.OnGamePhaseChanged += HandleGamePhaseChanged;
    }

    private void OnDisable()
    {
        GamePhaseManager.current.OnGamePhaseChanged -= HandleGamePhaseChanged;
    }

    void Start()
    {
        characterManager = GetComponent<CharacterManager>();

        OnTargetingSystemChanged.Invoke(this, new TargetingSystemChanged
        {
            actor = this.actor,
            target = this.target
        });
    }

    void Update()
    {
        if (active)
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
            
            if (!characterManager.GetCharacter(0, index).HasActedThisTurn)
                actor = characterManager.GetCharacter(0, index);
        }
        else
        {
            target = characterManager.GetCharacter(1, index);
        }

        OnTargetingSystemChanged.Invoke(this, new TargetingSystemChanged
        {
            actor = this.actor,
            target = this.target
        });
    }

    public void HandleGamePhaseChanged(object sender, GamePhaseChangeEventArgs e)
    {
        Actor = null;
        Target = null;

        if (e.newGamePhase.Name == EGamePhaseName.COMBAT_ACTION)
        {
            active = true;
        }
        else
            active = false;
    }
}

public class TargetingSystemChanged : EventArgs
{
    public Character actor;
    public Character target;
}
