using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Condition_", menuName = "Condition")]
public class ConditionData : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private StatToMonitor[] statToMonitorList;

    public string Name { get => name; }
    public StatToMonitor[] StatToMonitorList { get => statToMonitorList; }
}

[System.Serializable]
public struct StatToMonitor
{
    public StatData statToMonitor;
    public EStatComparator statComparator;
    public int thresholdValue;
}

public enum EStatComparator
{
    SUPERIOR,
    SUPERIOR_EQUAL,
    INFERIOR,
    INFERIOR_EQUAL
}
