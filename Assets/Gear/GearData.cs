using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gear_", menuName = "Gear/GearData")]
public class GearData : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private StatConfiguration[] statConfigurationList;
    [SerializeField] private BodyPartData bodyPartData;

    public string Name { get => name; }
    public StatConfiguration[] StatConfigurationList { get => statConfigurationList; }
    public BodyPartData BodyPartData { get => bodyPartData; }
}
