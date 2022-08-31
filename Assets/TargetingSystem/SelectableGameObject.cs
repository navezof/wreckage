using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectableGameObject : MonoBehaviour
{
    [SerializeField] private bool selectParent;

    private SelectorManager selectorManager;

    private void Start()
    {
        selectorManager = SelectorManager.current;
    }

    private void OnMouseDown()
    {
        if (selectParent)
        {
            selectorManager.Select(this.gameObject.transform.parent.gameObject);
        }
        else
            selectorManager.Select(this.gameObject);
    }
}
