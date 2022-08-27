using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    [SerializeField] private StatConfiguration[] statConfigurationList;

    private List<Stat> statlist = new List<Stat>();

    public List<Stat> Statlist { get => statlist; }

    private void Start() 
    {
        LoadConfigurationList(statConfigurationList);
    }

    public void LoadConfigurationList(StatConfiguration[] statConfigurationList)
    {
        if (this.statConfigurationList != statConfigurationList)
            this.statConfigurationList = statConfigurationList;

        foreach (StatConfiguration configuration in statConfigurationList)
        {
            if (GetStat(configuration.data) == null)
                statlist.Add(new Stat(this, configuration.data, configuration.baseValue));
        }
    }

    public Stat GetStat(StatData statData, bool createIfNotExisting = false)
    {
        foreach (Stat stat in Statlist)
        {
            if (stat.Data == statData)
                return stat;
        }
        return null;
    }

    static public IStatable GetSource(StatSource statSource, TargetingSystem targetingSystem)
    {
        switch (statSource.source)
        {
            case ETargetNumberModifierSource.ACTOR:
                return targetingSystem.Actor;
            case ETargetNumberModifierSource.ACTOR_GEAR:
                return targetingSystem.Actor.GetComponent<GearManager>().GetGear(statSource.linkedBodyPart);
            case ETargetNumberModifierSource.TARGET:
                return targetingSystem.Target;
            case ETargetNumberModifierSource.TARGET_GEAR:
                return targetingSystem.Target.GetComponent<GearManager>().GetGear(statSource.linkedBodyPart);
        }
        return null;
    }
}

[System.Serializable]
public struct StatConfiguration
{
    public StatData data;
    public string baseValue;
}

[System.Serializable]
public struct StatSource
{
    public StatData data;
    public ETargetNumberModifierSource source;
    public BodyPartData linkedBodyPart;
}
