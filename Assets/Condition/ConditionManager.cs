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

    private void OnEnable()
    {
        PlayerController.current.OnDisplayConditions += DisplayOnConsole;
    }

    private void OnDisable()
    {
        PlayerController.current.OnDisplayConditions -= DisplayOnConsole;
    }

    private void Start()
    {
        statManager = GetComponent<StatManager>();

        foreach (ConditionData conditionData in conditionDataList)
            conditionList.Add(new Condition(this, conditionData));
    }

    public void DisplayOnConsole(object sender, EventArgs e)
    {
        Debug.Log("<" + name + ">: Conditions:");
        foreach (Condition condition in conditionList)
        {
            condition.DisplayOnConsole();
        }
    }
}