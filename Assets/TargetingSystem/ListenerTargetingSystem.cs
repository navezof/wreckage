using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerTargetingSystem : MonoBehaviour
{
    public void HandleTargetingSystemChanged(object sender, TargetingSystemChanged e)
    {
        IListenToTargetingSystem[] listenerList = GetComponents<IListenToTargetingSystem>();
        foreach (IListenToTargetingSystem listener in listenerList)
        {
            listener.HandleTargetingSystemChanged(sender, e);
        }
    }

    private void OnEnable()
    {
        TargetingSystem.current.OnTargetingSystemChanged += HandleTargetingSystemChanged;
    }

    private void OnDisable()
    {
        TargetingSystem.current.OnTargetingSystemChanged -= HandleTargetingSystemChanged;
    }
}

public interface IListenToTargetingSystem
{
    public void HandleTargetingSystemChanged(object sender, TargetingSystemChanged e);
}
