using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorUI : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text firstText;
    [SerializeField] private TMPro.TMP_Text secondText;

    private void OnEnable() 
    {
        SelectorManager.current.OnSelectorChange += UpdateText;
        UpdateText(null, null);
    }

    private void OnDisable() 
    {
        SelectorManager.current.OnSelectorChange -= UpdateText;
    }

    private void UpdateText(GameObject first, GameObject second)
    {
        firstText.text = first ? first.name : "first empty";
        secondText.text = second ? second.name : "second empty";
    }
}
