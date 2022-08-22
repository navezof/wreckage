using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound
{
    private BodyPart bodyPart;
    private WoundData data;

    private string name;

    public Wound(BodyPart bodyPart, WoundData data)
    {
        this.bodyPart = bodyPart;
        this.data = data;

        this.name = data.name;    
    }

    public void DisplayOnConsole()
    {
        Debug.Log("--- " + name);
    }

}
