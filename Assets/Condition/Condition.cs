using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition
{
    private ConditionManager conditionManager;
    private ConditionData data;

    private string name;
    private StatToMonitor[] statToMonitorList;

    private bool active = false;
    public bool Active { get => active; }

    public Condition(ConditionManager conditionManager, ConditionData data)
    {
        this.conditionManager = conditionManager;
        this.data = data;
        this.name = data.name;
        this.statToMonitorList = data.StatToMonitorList;

        LinkToStat();
        SetActive(false);
    }

    private void LinkToStat()
    {
        StatManager statManager = conditionManager.GetComponent<StatManager>();
        foreach (StatToMonitor statMonitor in statToMonitorList)
        {
            statManager.GetStat(statMonitor.statToMonitor).OnStatChanged += HandleOnStatChange;
        }
    }

    public void HandleOnStatChange(object sender, StatChangedEventArgs e)
    {
        foreach (StatToMonitor statToMonitor in statToMonitorList)
        {
            if (IsConditionMet(statToMonitor))
            {
                SetActive(true);
                return ; 
            }
        }
        SetActive(false);
    }

    private void SetActive(bool active)
    {
        if (this.active != active)
        {
            Debug.Log("Condition: " + name + " is now " + active);
            this.active = active;
        }
    }

    private bool IsConditionMet(StatToMonitor statToMonitor)
    {
        Stat stat = conditionManager.StatManager.GetStat(statToMonitor.statToMonitor);

        switch (statToMonitor.statComparator)
        {
            case EStatComparator.SUPERIOR:
                if (stat.Value > statToMonitor.thresholdValue)
                    return true;
                return false;
            case EStatComparator.SUPERIOR_EQUAL:
                if (stat.Value >= statToMonitor.thresholdValue)
                    return true;
                return false;
            case EStatComparator.INFERIOR:
                if (stat.Value < statToMonitor.thresholdValue)
                    return true;
                return false;
            case EStatComparator.INFERIOR_EQUAL:
                if (stat.Value <= statToMonitor.thresholdValue)
                    return true;
                return false;
        }
        return false;        
    }

    public void DisplayOnConsole()
    {
        Debug.Log("--" + name);
        foreach (StatToMonitor statToMonitor in statToMonitorList)
        {
            Debug.Log("---" + statToMonitor.statToMonitor + " " + statToMonitor.statComparator + " " + statToMonitor.thresholdValue);
        }
    }
}
