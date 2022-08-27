using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour, IStatable
{
    private GearData data;

    private new string name;
    private StatManager statManager;    
    private BodyPartData bodyPartData;

    public GearData Data { get => data; }
    public string Name { get => name; }
    public StatManager StatManager { get => statManager; }
    public BodyPartData BodyPartData { get => bodyPartData; }

    public void Initialize(GearData data)
    {
        this.data = data;
        this.name = data.Name;
        this.bodyPartData = data.BodyPartData;

        this.statManager = GetComponent<StatManager>();
        this.statManager.LoadConfigurationList(data.StatConfigurationList);
    } 

    public Stat GetStat(StatData data)
    {
        if (statManager == null)
            statManager = GetComponent<StatManager>();
        return statManager.GetStat(data);
    }
}
