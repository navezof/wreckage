using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GearData", menuName = "Gear/GearData")]
public class GearData : ScriptableObject
{
    [SerializeField] private new string name;
}
