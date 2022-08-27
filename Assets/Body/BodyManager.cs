using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    [SerializeField] private BodyPartData[] bodyPartDataList;
    private List<BodyPart> bodyPartList = new List<BodyPart>();

    public List<BodyPart> BodyPartList { get => bodyPartList; }

    void Awake()
    {
        foreach (BodyPartData data in bodyPartDataList)
            BodyPartList.Add(new BodyPart(this, data));
    }

    public BodyPart GetBodyPart(BodyPartData bodyPartData)
    {
        foreach (BodyPart bodyPart in BodyPartList)
        {
            if (bodyPart.Data == bodyPartData)
                return bodyPart;
        }
        return null;
    }

    public BodyPart GetBodyPart(int index)
    {
        return bodyPartList[index];
    }
}
