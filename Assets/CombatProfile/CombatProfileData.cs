using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CombatProfile_", menuName = "Combat Profile")]
public class CombatProfileData : ScriptableObject
{
    [SerializeField] private GamePhaseData[] updatePhaseList;
    [SerializeField] private int team;

    public GamePhaseData[] UpdatePhaseList { get => updatePhaseList; }
    public int Team { get => team; set => team = value; }
}
