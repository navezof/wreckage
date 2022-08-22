using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart
{
    private string name;
    private BodyPartData data;
    private BodyManager bodyManager;

    private List<Wound> wounds = new List<Wound>();

    public BodyPartData Data { get => data; }

    public BodyPart(BodyManager bodyManager, BodyPartData data)
    {
        this.bodyManager = bodyManager;

        this.data = data;
        this.name = data.name;
    }


    public Wound AddWound()
    {
        return null;
    }

    public void DisplayOnConsole()
    {
        Debug.Log("-- " + name);
        Debug.Log("--> Wound:");
        foreach (Wound wound in wounds)
        {
            wound.DisplayOnConsole();
        }
        Debug.Log("--> Potential Wound:");
        foreach (WoundData woundData in Data.WoundDataList)
        {
            Debug.Log("--- " + woundData.Name);
        }
    }
}
