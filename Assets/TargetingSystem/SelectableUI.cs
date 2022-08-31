using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableUI : MonoBehaviour, IPointerClickHandler
{
    private GameObject data;
    private SelectorManager selectorManager;

    private void Start()
    {
        selectorManager = FindObjectOfType<SelectorManager>();
    }

    public void LinkWithData(GameObject data)
    {
        this.data = data;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Pointer click");
        selectorManager.Select(data);
    }
}
