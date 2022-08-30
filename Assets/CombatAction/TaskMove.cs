using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMove : ATask
{
    [SerializeField] private PositionModification positionModification;
    [SerializeField] private OrientationModification orientationModification;
    [SerializeField] private Transform player;

    public override void Execute()
    {
        player.transform.position = player.transform.position + (new Vector3(positionModification.x, positionModification.y, positionModification.Z));
        player.transform.eulerAngles = (new Vector3(player.eulerAngles.x + orientationModification.x, player.eulerAngles.y + orientationModification.y, player.eulerAngles.z + orientationModification.z));

        ExecuteNextTask();
    }
}

[System.Serializable]
public struct PositionModification
{
    public float x;
    public float y;
    public float Z;
}

[System.Serializable]
public struct OrientationModification
{
    public float x;
    public float y;
    public float z;
}

