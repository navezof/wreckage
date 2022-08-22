using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WoundData", menuName = "Body/Wound")]
public class WoundData : ScriptableObject
{
    [SerializeField] private new string name;

    public string Name { get => name; }
}
