using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear
{
    private string name;
    private GearData data;

    public GearData Data { get => data; }
    public string Name { get => name; }

    public Gear(GearData data)
    {
        this.data = data;
        this.name = data.Name;
    }
}
