using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionUI : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text conditionText;
    private Condition condition;

    public void LinkToStat(Condition condition)
    {
        this.condition = condition;

        condition.OnConditionChanged += HandleOnConditionChange;

        UpdateText();
    }

    private void OnDisable()
    {
        condition.OnConditionChanged -= HandleOnConditionChange;
    }

    public void HandleOnConditionChange(object sender, ConditionChangedEventArgs e)
    {
        if (e.condition != condition)
            condition = e.condition;

        UpdateText();
    }

    private void UpdateText()
    {        
        if (condition.Active)
        {
            conditionText.enabled = true;
            conditionText.text = condition.Name;
        }
        else
        {
            conditionText.enabled = false;
        }
    }
}
