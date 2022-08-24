using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear
{
    private GearData data;

    public GearData Data { get => data; }

    public Gear(GearData data)
    {
        this.data = data;
    }
}
