using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabList;
    [SerializeField] private int playerTeamNumberOfCharacter;
    [SerializeField] private int AITeamNumberOfCharacter;    

    private List<GameObject> characterList = new List<GameObject>();

    public List<GameObject> CharacterList { get => characterList;}

    public EventHandler<OnCharacterCreatedEventArgs> OnCharacterCreated;

    void Start()
    {
        CreateCharacters();
    }

    private void CreateCharacters()
    {
        foreach (GameObject characterPrefab in characterPrefabList)
        {
            GameObject newCharacter = Instantiate(characterPrefab, this.transform);
            characterList.Add(newCharacter);
            newCharacter.name = newCharacter.GetComponent<CombatProfileManager>().GetName();

            OnCharacterCreated?.Invoke(this, new OnCharacterCreatedEventArgs
            {
                character = newCharacter
            });
        }
    }

    public GameObject GetCharacter(int teamNumber)
    {
        foreach (GameObject character in characterList)
        {
            if (character.GetComponent<CombatProfileManager>().GetTeam() == teamNumber)
                return character;
        }
        return null;
    }

    public GameObject GetCharacter(int teamNumberToGet, int indexToGet)
    {
        int index = 0;
        foreach (GameObject character in characterList)
        {
            if (character.GetComponent<CombatProfileManager>().GetTeam() == teamNumberToGet)
            {
                if (index == indexToGet)
                    return character;
                index++;
            }     
        }
        return null;
    }
}

public class OnCharacterCreatedEventArgs : EventArgs
{
    public GameObject character;
}
