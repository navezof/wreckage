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
        characterManager.OnTeamMemberCreated += OnTeamMemberCreated;    
    }

    private void OnDisable() 
    {
        characterManager.OnTeamMemberCreated -= OnTeamMemberCreated;
    }

    public void OnTeamMemberCreated(object sender, OnTeamMemberCreatedEventArgs e)
    {
        GameObject newCharacterUI = Instantiate(characterUIPrefab, this.transform);
        CharacterUI character = newCharacterUI.GetComponent<CharacterUI>();
        character.LinkWithData(e.character);
    }
    
}
