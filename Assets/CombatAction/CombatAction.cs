using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAction : MonoBehaviour, IStatable
{
    [SerializeField] private new string name;
    [SerializeField] private ATask firstTask;
    [SerializeField] private ARequirement[] requirementList;
    [SerializeField] private KeyCode keyCode;

    private StatManager statManager;
    private TargetingSystem targetingSystem;
    private bool isActive = false;

    public string Name { get => name; }
    public KeyCode KeyCode { get => keyCode; }

    private void Start()
    {
        targetingSystem = TargetingSystem.current;
        statManager = GetComponent<StatManager>();
    }


    private void OnEnable() 
    {
        isActive = true;
    }

    private void OnDisable() 
    {
        isActive = false;
    }

    private void Update()
    {
        if (!isActive)
            return ;
        if (Input.GetKeyDown(KeyCode))
        {
            if (IsValid())
            {
                firstTask.InitializeTask(this);
                firstTask.Execute();
            }
            else
            {
                Debug.Log("Action " + Name + " is invalid");
            }
        }
    }

    public bool IsValid()
    {   
        return (CheckActor() && CheckRequirement());
    }

    private bool CheckActor()
    {
        if (targetingSystem.Actor == null)
            return false;
        return true;
    }
    
    private bool CheckRequirement()
    {
        foreach (ARequirement requirement in requirementList)
        {
            if (!requirement.IsMet())
                return false;
        }
        return true;
    }

    public Stat GetStat(StatData data)
    {
        if (statManager == null)
            statManager = GetComponent<StatManager>();
        return statManager.GetStat(data);
    }
}
