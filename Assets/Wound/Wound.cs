using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound
{
    private StatManager statManager;

    private BodyPart bodyPart;
    private WoundData data;
    private string name;
    private WoundModifier[] woundModifierList;
    private WoundModifier[] woundChangePerTurnList;

    private bool healed = false;

    public WoundData Data { get => data; set => data = value; }

    public Wound(BodyPart bodyPart, WoundData data)
    {        
        this.bodyPart = bodyPart;
        this.Data = data;

        this.name = data.Name;
        this.woundModifierList = data.WoundModifierList;
        this.woundChangePerTurnList = data.WoundChangePerTurnList;

        this.statManager = bodyPart.BodyManager.GetComponent<StatManager>();

        ApplyWoundModifier();

        SubscribeToEvent();
    }

    public void SubscribeToEvent()
    {
        GamePhaseManager.current.OnGamePhaseChanged += ApplyWoundChangePerTurn;
    }

    public void UnsubscribeFromEvent()
    {
        GamePhaseManager.current.OnGamePhaseChanged -= ApplyWoundChangePerTurn;
    }

    private void ApplyWoundModifier()
    {
        foreach (WoundModifier woundModifier in woundModifierList)
            statManager.GetStat(woundModifier.statToTarget)?.AddModifier(woundModifier.change, 99, this, this.name + " (wound)");            
    }

    private void RemoveWoundModifier()
    {
        foreach (WoundModifier woundModifier in woundModifierList)
            statManager.GetStat(woundModifier.statToTarget)?.RemoveAllModifiersFromSource(this);            
    }

    private void ApplyWoundChangePerTurn(object sender, GamePhaseChangeEventArgs e)
    {
        if (e.newGamePhase.Name != EGamePhaseName.STATUS_UPDATE)
            return;

        if (healed)
            return ;

        foreach (WoundModifier woundChangePerTurn in woundChangePerTurnList)
            statManager.GetStat(woundChangePerTurn.statToTarget)?.AddModifier(woundChangePerTurn.change, 99, this, this.name + " (woundChangePerTurn)");
    }
    
    public void DisplayOnConsole()
    {
        Debug.Log("--- " + name + ", WoundModifier:");
        foreach(WoundModifier woundModifier in woundModifierList)
            Debug.Log("---- " + woundModifier.statToTarget + " > " + woundModifier.change);
                Debug.Log("--- WoundChangePerTurnList:");
        foreach(WoundModifier woundModifier in woundChangePerTurnList)
            Debug.Log("---- " + woundModifier.statToTarget + " > " + woundModifier.change);
    }

}
