using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart
{
    private string name;
    private BodyPartData data;
    private BodyManager bodyManager;

    private WoundData[] woundDataList;
    private List<Wound> wounds = new List<Wound>();

    public BodyPartData Data { get => data; }
    public BodyManager BodyManager { get => bodyManager; set => bodyManager = value; }

    public BodyPart(BodyManager bodyManager, BodyPartData data)
    {
        this.BodyManager = bodyManager;

        this.data = data;
        this.name = data.Name;
        this.woundDataList = data.WoundDataList;
    }

    public void AddWound()
    {
        int roll = Random.Range(1, woundDataList.Length - 1);

        wounds.Add(new Wound(this, woundDataList[0]));
    }

    public void RemoveWound(WoundData woundData)
    {
        for (int i = wounds.Count - 1; i >= 0; i--)
        {
            if (wounds[i].Data == woundData)
            {
                wounds[i].UnsubscribeFromEvent();
                wounds[i].RemoveWoundModifier();
                wounds.RemoveAt(i);
            }
        }
    }
}
