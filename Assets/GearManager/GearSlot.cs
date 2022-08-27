using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSlot
{
    private GearManager gearManager;
    private GearSlotListData gearSlotListData;
    private GearSlotData data;

    private BodyPartData linkedBodypart;

    private Gear gear;

    public event EventHandler<GearSlotChangedEventArgs> OnGearSlotChanged;

    public GearSlotListData GearSlotListData { get => gearSlotListData; set => gearSlotListData = value; }
    public GearSlotData Data { get => data; }
    public Gear Gear { get => gear; }
    public BodyPartData LinkedBodypart { get => linkedBodypart; set => linkedBodypart = value; }

    public GearSlot(GearManager gearManager, GearSlotListData gearSlotListData, GearSlotData data)
    {
        this.gearManager = gearManager;
        this.GearSlotListData = gearSlotListData;
        this.data = data;

        this.linkedBodypart = data.linkedBodyPart;
    }

    public bool IsValidSlot()
    {
        return true;
    }

    public void AddGear(Gear gear)
    {
        this.gear = gear;

        OnGearSlotChanged?.Invoke(this, new GearSlotChangedEventArgs{
            gearSlot = this
        });
    }

    public void RemoveGear()
    {
        this.gear = null;
    }
}

public class GearSlotChangedEventArgs : EventArgs
{
    public GearSlot gearSlot;
}
