using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wound_", menuName = "Wound")]
public class WoundData : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private WoundModifier[] woundModifierList;
    [SerializeField] private WoundModifier[] woundChangePerTurnList;
    [SerializeField] private int healingDifficulty;
    [SerializeField] private GamePhaseData[] updatePhaseList;

    public string Name { get => name; }
    public WoundModifier[] WoundModifierList { get => woundModifierList; }
    public WoundModifier[] WoundChangePerTurnList { get => woundChangePerTurnList; }
    public GamePhaseData[] UpdatePhaseList { get => updatePhaseList; }
}

[System.Serializable]
public struct WoundModifier
{
    public StatData statToTarget;
    public int change;
}