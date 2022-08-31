using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{    
    [SerializeField] protected TMPro.TMP_Text text;

    protected GameObject data;

    public void Initialize(GameObject data)
    {
        LinkWithData(data);

        GetComponent<SelectableUI>()?.LinkWithData(data);

        name = data.name + "_UI";

        Show();
    }

    public void Show()
    {
        UpdateText();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void LinkWithData(GameObject data)
    {
        this.data = data;
    }

    protected abstract void UpdateText();
}
