using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAction : MonoBehaviour, IStatable
{
    [SerializeField] private new string name;
    [SerializeField] private ATask firstTask;
    [SerializeField] private ARequirement[] requirementList;
    [SerializeField] private AGameActionLimiter gameActionLimiter;

    private StatManager statManager;
    private TargetingSystem targetingSystem;

    public string Name { get => name; }

    public event EventHandler OnGameActionStart;
    public event EventHandler OnGameActionEnd;

    private void Start()
    {
        statManager = GetComponent<StatManager>();
    }

    public void Trigger()
    {
        if (IsValid())
        {
            OnGameActionStart?.Invoke(this, EventArgs.Empty);

            firstTask.InitializeTask(this);
            firstTask.Execute();

            OnGameActionEnd?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Debug.Log("Action " + Name + " is invalid");
        }
    }

    public bool IsValid()
    {
        if (LimitationReached())
            return false;    
        if (!RequirementMet())
            return false;
        return true;
    }

    private bool RequirementMet()
    {
        foreach (ARequirement requirement in requirementList)
        {
            if (!requirement.IsMet())
                return false;
        }
        return true;
    }

    private bool LimitationReached()
    {
        if (gameActionLimiter == null)
            return false;
        if (gameActionLimiter.IsLimited())
            return true;
        return false;
    }

    public Stat GetStat(StatData data)
    {
        if (statManager == null)
            statManager = GetComponent<StatManager>();
        return statManager.GetStat(data);
    }
}
