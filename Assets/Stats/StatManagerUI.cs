using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject statUIPrefab;
    private StatManager statManager;

    void Start()
    {
        CharacterUI characterUI = GetComponentInParent<CharacterUI>();

        statManager = characterUI.Character.GetComponent<StatManager>();
        foreach (Stat stat in statManager.Statlist)
        {
            GameObject newStatUi = Instantiate(statUIPrefab, this.transform);
            StatUI statUI = newStatUi.GetComponent<StatUI>();
            statUI.LinkToStat(stat);
        }
    }
}
