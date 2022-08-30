using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private Transform parent;

    private void Start()
    {
        GameObject spawn = Instantiate(prefabToSpawn, this.transform);
        spawn.transform.SetParent(parent);
    }
}
