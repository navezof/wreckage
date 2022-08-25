using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodyPart_", menuName = "Body/BodyPart")]
public class BodyPartData : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private WoundData[] woundDataList;

    public string Name { get => name; }
    public WoundData[] WoundDataList { get => woundDataList; }    
}
