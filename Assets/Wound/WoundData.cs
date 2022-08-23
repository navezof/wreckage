using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WoundData", menuName = "Body/Wound")]
public class WoundData : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private WoundModifier[] woundModifierList;
    [SerializeField] private WoundModifier[] woundChangePerTurnList;
    [SerializeField] private int healingDifficulty;

    public string Name { get => name; }
    public WoundModifier[] WoundModifierList { get => woundModifierList; }
    public WoundModifier[] WoundChangePerTurnList { get => woundChangePerTurnList; }
}

[System.Serializable]
public struct WoundModifier
{
    public StatData statToTarget;
    public int change;
}