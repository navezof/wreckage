using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    [SerializeField] private BodyPartData[] bodyPartDataList;
    private List<BodyPart> bodyPartList = new List<BodyPart>();

    private void OnEnable() 
    {
        if (PlayerController.current == null)
            Debug.Log("null");
        PlayerController.current.OnDisplayBody += HandleDisplayOnConsole; 
    }

    private void OnDisable() 
    {
        PlayerController.current.OnDisplayBody -= HandleDisplayOnConsole; 
    }

    void Awake()
    {
        foreach (BodyPartData data in bodyPartDataList)
            bodyPartList.Add(new BodyPart(this, data));
    }

    public BodyPart GetBodyPart(BodyPartData bodyPartData)
    {
        foreach (BodyPart bodyPart in bodyPartList)
        {
            if (bodyPart.Data == bodyPartData)
                return bodyPart;
        }
        return null;
    }

    private void HandleDisplayOnConsole(object sender, EventArgs e)
    {
        Debug.Log(name + " > BodyParts:");
        foreach (BodyPart bodyPart in bodyPartList)
        {            
            bodyPart.DisplayOnConsole();
        }
    }
}
