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

    private void OnEnable() 
    {
        PlayerController.current.OnDisplayStats += HandleDisplayOnConsole; 
    }

    private void OnDisable() 
    {
        PlayerController.current.OnDisplayStats -= HandleDisplayOnConsole; 
    }

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

    private void HandleDisplayOnConsole(object sender, EventArgs e)
    {
        Debug.Log(name + " > Stats:");
        foreach (Stat stat in Statlist)
        {            
            stat.DisplayOnConsole();
        }
    }

    public Stat GetStat(StatData statData)
    {
        foreach (Stat stat in Statlist)
        {
            if (stat.Data == statData)
                return stat;
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
