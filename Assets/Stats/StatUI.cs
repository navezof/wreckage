using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUI : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text statText;
    private Stat stat;

    public void LinkToStat(Stat stat)
    {
        this.stat = stat;

        stat.OnStatChanged += HandleOnStatChange;

        UpdateText();
    }

    private void OnDisable()
    {
        stat.OnStatChanged -= HandleOnStatChange;
    }

    public void HandleOnStatChange(object sender, StatChangedEventArgs e)
    {
        if (e.stat != stat)
            stat = e.stat;

        UpdateText();
    }

    private void UpdateText()
    {
        string modifiers = "";
        foreach (StatModifier statModifier in stat.StatModifierList)
        {
            modifiers += " [ " + statModifier.Value + " " + statModifier.Description + " ]";
        }
        statText.text = stat.Name + " " + stat.Value + modifiers;
    }
}
