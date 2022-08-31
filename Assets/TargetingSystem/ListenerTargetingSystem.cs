using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerTargetingSystem : MonoBehaviour
{
    public void HandleTargetingSystemChanged(GameObject first, GameObject second)
    {
        IListenToTargetingSystem[] listenerList = GetComponents<IListenToTargetingSystem>();
        foreach (IListenToTargetingSystem listener in listenerList)
        {
            listener.HandleTargetingSystemChanged(first, second);
        }
    }

    private void OnEnable()
    {
        SelectorManager.current.OnSelectorChange += HandleTargetingSystemChanged;
        // TargetingSystem.current.OnTargetingSystemChanged += HandleTargetingSystemChanged;
    }

    private void OnDisable()
    {
        SelectorManager.current.OnSelectorChange -= HandleTargetingSystemChanged;
        // TargetingSystem.current.OnTargetingSystemChanged -= HandleTargetingSystemChanged;
    }
}

public interface IListenToTargetingSystem
{
    public void HandleTargetingSystemChanged(GameObject first, GameObject second);
    // public void HandleTargetingSystemChanged(object sender, TargetingSystemChanged e);
}
