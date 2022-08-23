using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePhaseData", menuName = "GamePhase/New Game Phase")]
public class GamePhaseData : ScriptableObject
{
    [SerializeField] private new EGamePhaseName name;
    public EGamePhaseName Name { get { return name; } private set {} }
    
    [SerializeField] private GamePhaseData nextPhaseData;
    public GamePhaseData NextPhaseData { get { return nextPhaseData; } private set {} }
}
