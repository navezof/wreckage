using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatData", menuName = "Character/Stat")]
public class StatData : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private string shortName;
    [SerializeField] private string baseValue;

    public string Name { get => name; }
    public string ShortName { get => shortName; }
    public string BaseValue { get => baseValue; }
}
