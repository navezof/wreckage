using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject characterUIPrefab;
    [SerializeField] private CharacterManager characterManager;
 
    private void OnEnable() 
    {
        characterManager.OnCharacterCreated += OnTeamMemberCreated;    
    }

    private void OnDisable() 
    {
        characterManager.OnCharacterCreated -= OnTeamMemberCreated;
    }

    public void OnTeamMemberCreated(object sender, OnCharacterCreatedEventArgs e)
    {
        GameObject newCharacterUI = Instantiate(characterUIPrefab, this.transform);
        CharacterUI characterUI = newCharacterUI.GetComponent<CharacterUI>();
        characterUI.LinkWithData(e.character);

        newCharacterUI.name = e.character.GetComponent<CombatProfileManager>().GetName() + " (UI)";
    }
}
