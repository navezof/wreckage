using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GearSlotListData", menuName = "Gear/GearSlotList")]
public class GearSlotListData : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] private GearSlotData[] gearSlotDataList;

    public string Name { get => name; }
    public GearSlotData[] GearSlotDataList { get => gearSlotDataList; }
}

[System.Serializable]
public struct GearSlotData 
{
    public BodyPartData linkedBodyPart;
}
