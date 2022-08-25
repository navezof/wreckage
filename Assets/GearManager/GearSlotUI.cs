using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSlotUI : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text gearText;
    private GearSlot gearSlot;

    public void LinkToStat(GearSlot gearSlot)
    {
        this.gearSlot = gearSlot;

        gearSlot.OnGearSlotChanged += HandleGearSlotChanged;

        UpdateText();
    }

    private void OnDisable()
    {
        gearSlot.OnGearSlotChanged -= HandleGearSlotChanged;
    }

    public void HandleGearSlotChanged(object sender, GearSlotChangedEventArgs e)
    {
        UpdateText();
    }

    private void UpdateText()
    {        
        string text = " - ";
        if (gearSlot.Gear != null)
        {
            text += gearSlot.Gear.Name + "( ";
            foreach (Stat stat in gearSlot.Gear.StatManager.Statlist)
            {
                text += stat.ShortName + stat.Value + "; ";
            }
            text += ")";
        }
        gearText.text = gearSlot.LinkedBodypart?.Name + text;
    }
}
