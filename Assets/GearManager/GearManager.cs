using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    [SerializeField] private GearSlotListData[] gearSlotListDataList;
    private List<GearSlot> gearSlotlist = new List<GearSlot>();

    void Start()
    {
        foreach (GearSlotListData gearSlotListData in gearSlotListDataList)
        {   
            Debug.Log("Createing inventory: " + gearSlotListData.Name);      
            foreach (GearSlotData gearSlotData in gearSlotListData.GearSlotDataList)
            {
                gearSlotlist.Add(new GearSlot(this, gearSlotListData, gearSlotData));
            }
        }
    }

    public GearSlot GetFirstEmptyGearSlot()
    {
        foreach (GearSlot gearSlot in gearSlotlist)
        {
            if (gearSlot.Gear == null)
                return gearSlot;
        }
        return null;
    }

    public GearSlot GetFirstEmptyGearSlot(BodyPartData bodyPartData)
    {
        foreach (GearSlot gearSlot in gearSlotlist)
        {
            if (gearSlot.Gear == null && gearSlot.LinkedBodypart == bodyPartData)
                return gearSlot;
        }
        return null;
    }

    public Gear GetGear(GearData gearData)
    {
        foreach (GearSlot gearSlot in gearSlotlist)
        {
            if (gearSlot.Gear.Data == gearData)
                return gearSlot.Gear;
        }
        return null;    
    }

    public Gear GetGear(BodyPartData bodyPartData)
    {
        foreach (GearSlot gearSlot in gearSlotlist)
        {
            if (gearSlot.LinkedBodypart == bodyPartData)
                return gearSlot.Gear;
        }
        return null; 
    }

    public List<GearSlot> GetGearSlotList(GearSlotListData gearSlotListData)
    {
        List<GearSlot> gearSlotList = new List<GearSlot>();

        foreach (GearSlot gearSlot in gearSlotlist)
        {
            if (gearSlot.GearSlotListData == gearSlotListData)
                gearSlotList.Add(gearSlot);
        }
        return gearSlotList;
    }
}