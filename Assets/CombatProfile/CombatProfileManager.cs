using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatProfileManager : MonoBehaviour
{
    [SerializeField] private CombatProfileData data;

    private CombatProfile combatProfile;

    public CombatProfile CombatProfile { get => combatProfile; }

    public void Awake()
    {
        this.combatProfile = new CombatProfile(data);
    }

    public string GetName()
    {
        return CombatProfile.Name;
    }

    public bool GetHasActedThisTurn()
    {
        return CombatProfile.HasActedThisTurn;
    }

    public void SetHasActedThisTurn(bool value)
    {
        CombatProfile.HasActedThisTurn = value;
    }

    public int GetTeam()
    {
        return CombatProfile.Team;
    }

    public void SetTeam(int team)
    {
        if (CombatProfile == null)
            Debug.Log("Set team null");
        CombatProfile.Team = team;
    }
}
