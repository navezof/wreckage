using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour
{

    [Header("DEBUG")]
    public BodyPartData DEBUG_bodyPartToWound;
    public WoundData DEBUG_WoundToRemove;

    [SerializeField] private BodyPartData[] bodyPartDataList;
    private List<BodyPart> bodyPartList = new List<BodyPart>();

    private void OnEnable() 
    {
        PlayerController.current.OnDisplayBody += HandleDisplayOnConsole;
        PlayerController.current.OnAddWound += AddWound;
        PlayerController.current.OnRemoveWound += RemoveWound;
    }

    private void OnDisable() 
    {
        PlayerController.current.OnDisplayBody -= HandleDisplayOnConsole;
        PlayerController.current.OnAddWound -= AddWound;
        PlayerController.current.OnRemoveWound -= RemoveWound;
    }

    void Awake()
    {
        foreach (BodyPartData data in bodyPartDataList)
            bodyPartList.Add(new BodyPart(this, data));
    }

    public void AddWound(object sender, EventArgs e)
    {
        GetBodyPart(DEBUG_bodyPartToWound)?.AddWound();
    }    

    public void RemoveWound(object sender, EventArgs e)
    {
        GetBodyPart(DEBUG_bodyPartToWound)?.RemoveWound(DEBUG_WoundToRemove);
    }

    public BodyPart GetBodyPart(BodyPartData bodyPartData)
    {
        foreach (BodyPart bodyPart in bodyPartList)
        {
            if (bodyPart.Data == bodyPartData)
                return bodyPart;
        }
        Debug.Log(bodyPartData.Name + " not found");
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
