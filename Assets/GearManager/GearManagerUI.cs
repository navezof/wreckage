using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject gearUIPrefab;
    private GearManager gearManager;


    // Start is called before the first frame update
    void Start()
    {
        CharacterUI characterUI = GetComponentInParent<CharacterUI>();

        gearManager = characterUI.Character.GetComponent<GearManager>();
        foreach (GearSlot gearSlot in gearManager.GearSlotlist)
        {
            GameObject newGear = Instantiate(gearUIPrefab, this.transform);
            GearSlotUI gearSlotUI = newGear.GetComponent<GearSlotUI>();
            gearSlotUI.LinkToStat(gearSlot);
        }
    }
}
