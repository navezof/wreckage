using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseListener : MonoBehaviour
{
    [SerializeField] private EGamePhaseName gamePhaseToActivateTo;

    private void Start()
    {
        SetActive(false);
    }

    private void OnEnable()
    {
        GamePhaseManager.current.OnGamePhaseChanged += HandleGamePhaseChanged;
    }

    private void OnDisable()
    {
        GamePhaseManager.current.OnGamePhaseChanged -= HandleGamePhaseChanged;
    }

    private void HandleGamePhaseChanged(object sender, GamePhaseChangeEventArgs e)
    {
        if (gamePhaseToActivateTo == e.newGamePhase.Name)
            SetActive(true);
        else
            SetActive(false);
    }

    private void SetActive(bool active)
    {
        MonoBehaviour[] componentlist = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour component in componentlist)
        {
            if (component != this)
                component.enabled = active;
        }
        foreach (Transform children in transform)
        {
            children.gameObject.SetActive(active);
        }
    }
}
