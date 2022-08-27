using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    [Header("DEBUG")]
    public GameObject GearPrefab;
    public GearData startingGear1;
    public GearData startingGear2;
    public GearData startingGear3;

    [SerializeField] private GearSlotListData[] gearSlotListDataList;
    private List<GearSlot> gearSlotlist = new List<GearSlot>();

    public List<GearSlot> GearSlotlist { get => gearSlotlist; }

    void Start()
    {
        foreach (GearSlotListData gearSlotListData in gearSlotListDataList)
        {
            foreach (GearSlotData gearSlotData in gearSlotListData.GearSlotDataList)
            {
                GearSlotlist.Add(new GearSlot(this, gearSlotListData, gearSlotData));
            }
        }

        TEST_ADDINVENTORY();        
    }

    public void TEST_ADDINVENTORY()
    {        
        Gear gear1 = CreateGear(startingGear1);
        Gear gear2 = CreateGear(startingGear2);
        Gear gear3 = CreateGear(startingGear3);

        AddToInventory(gear1);
        AddToInventory(gear2);
        AddToInventory(gear3);
    }

    public void AddToInventory(Gear gear)
    {
        GearSlot slot = GetFirstEmptyGearSlot(gear.BodyPartData);
        if (slot == null)
            slot = GetFirstEmptyGearSlot();
        if (slot == null)
        {
            Debug.Log("No more space in inventory");
            return ;
        }
        slot.AddGear(gear);
    }

    public Gear CreateGear(GearData data)
    {
        GameObject newGear = Instantiate(GearPrefab, this.transform);        
        Gear gear = newGear.GetComponent<Gear>();
        gear.Initialize(data);
        newGear.name = gear.Name;
        return gear;
    }

    public GearSlot GetFirstEmptyGearSlot()
    {
        foreach (GearSlot gearSlot in GearSlotlist)
        {
            if (gearSlot.Gear == null)
                return gearSlot;
        }
        return null;
    }

    public GearSlot GetFirstEmptyGearSlot(BodyPartData bodyPartData)
    {
        foreach (GearSlot gearSlot in GearSlotlist)
        {
            if (gearSlot.Gear == null && gearSlot.LinkedBodypart == bodyPartData)
                return gearSlot;
        }
        return null;
    }

    public Gear GetGear(GearData gearData)
    {
        foreach (GearSlot gearSlot in GearSlotlist)
        {
            if (gearSlot.Gear.Data == gearData)
                return gearSlot.Gear;
        }
        return null;
    }

    public Gear GetGear(BodyPartData bodyPartData)
    {
        foreach (GearSlot gearSlot in GearSlotlist)
        {
            if (gearSlot.LinkedBodypart == bodyPartData)
                return gearSlot.Gear;
        }
        return null;
    }

    public List<GearSlot> GetGearSlotList(GearSlotListData gearSlotListData)
    {
        List<GearSlot> gearSlotList = new List<GearSlot>();

        foreach (GearSlot gearSlot in GearSlotlist)
        {
            if (gearSlot.GearSlotListData == gearSlotListData)
                gearSlotList.Add(gearSlot);
        }
        return gearSlotList;
    }
}