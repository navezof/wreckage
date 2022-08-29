using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseListener : MonoBehaviour
{
    [SerializeField] private GamePhaseData[] activePhaseDataList;

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
        SetActive(false);
        foreach (GamePhaseData activePhaseData in activePhaseDataList)
        {
            if (activePhaseData == e.currentGamePhase)
                SetActive(true);
        }
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
