using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatProfile : PhaseBehaviour
{
    private string name;
    private int team;
    private bool hasActedThisTurn;

    public string Name { get => name; }
    public int Team { get => team ; set => team = value ; }
    public bool HasActedThisTurn { get => hasActedThisTurn; set => hasActedThisTurn = value; }

    public CombatProfile(CombatProfileData data) : base(data.UpdatePhaseList)
    {
        this.team = data.Team;
        this.name = Random.Range(1, 100).ToString() + "_" + team.ToString();
        
        this.hasActedThisTurn = false;
    }

    protected override void Update()
    {
        this.hasActedThisTurn = false;        
    }
}
