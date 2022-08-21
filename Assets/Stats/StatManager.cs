using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    [SerializeField] private StatConfiguration[] statConfigurationList;

    private List<Stat> statlist = new List<Stat>();

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
        foreach (StatConfiguration configuration in statConfigurationList)
        {
            statlist.Add(new Stat(configuration.data, configuration.baseValue));
        }
    }

    private void HandleDisplayOnConsole(object sender, EventArgs e)
    {
        Debug.Log(name + " > Stats:");
        foreach (Stat stat in statlist)
        {            
            stat.DisplayOnConsole();
        }
    }
}

[System.Serializable]
public struct StatConfiguration
{
    public StatData data;
    public string baseValue;
}
