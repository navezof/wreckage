using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectorManager : MonoBehaviour
{
    public static SelectorManager current;

    private GameObject first;
    private GameObject second;

    public GameObject First { get => first; set => first = value; }
    public GameObject Second { get => second; set => second = value; }

    public event UnityAction<GameObject, GameObject> OnSelectorChange;

    private void Awake()
    {
        current = this;

        Reset();
    }

    private void OnEnable()
    {
        Reset();
    }

    public void Select(GameObject gameObject)
    {
        if (First == null)
        {
            First = gameObject;
            OnSelectorChange?.Invoke(First, Second);
            return;
        }
        if (Second == null)
        {
            Second = gameObject;
            OnSelectorChange?.Invoke(First, Second);
            return;
        }
        Reset();
        Select(gameObject);
    }

    public void Reset()
    {
        first = null;
        second = null;

        OnSelectorChange?.Invoke(First, Second);
    }
}
