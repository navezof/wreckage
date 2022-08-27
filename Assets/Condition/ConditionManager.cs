using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionManager : MonoBehaviour
{
    [SerializeField] private ConditionData[] conditionDataList;

    private StatManager statManager;

    private List<Condition> conditionList = new List<Condition>();

    public StatManager StatManager { get => statManager; }
    public List<Condition> ConditionList { get => conditionList; }

    private void Start()
    {
        statManager = GetComponent<StatManager>();

        foreach (ConditionData conditionData in conditionDataList)
            ConditionList.Add(new Condition(this, conditionData));
    }

    public Condition GetCondition(ConditionData conditionData)
    {
        foreach (Condition condition in conditionList)
        {
            if (condition.Data == conditionData)
                return condition;
        }
        return null;
    }
}
