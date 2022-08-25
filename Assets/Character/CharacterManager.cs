using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private int playerTeamNumberOfCharacter;
    [SerializeField] private int AITeamNumberOfCharacter;    

    private List<Character> characterList = new List<Character>();

    public List<Character> CharacterList { get => characterList;}

    public EventHandler<OnTeamMemberCreatedEventArgs> OnTeamMemberCreated;

    void Start()
    {
        CreateTeamMember(0, playerTeamNumberOfCharacter);
        CreateTeamMember(1, AITeamNumberOfCharacter);
    }

    private void CreateTeamMember(int team, int memberInTeam)
    {
        for (int index = 0; index < memberInTeam; index++)
        {
            Character newCharacter = null;
            GameObject newTeamMemberGO = Instantiate(characterPrefab, this.transform);
            newCharacter = newTeamMemberGO.GetComponent<Character>();
            newCharacter.Name = UnityEngine.Random.Range(1, 100).ToString();
            newCharacter.Team = team;
            newTeamMemberGO.name = newCharacter.Name + "_" + team.ToString();

            characterList.Add(newCharacter);

            OnTeamMemberCreated?.Invoke(this, new OnTeamMemberCreatedEventArgs
            {
                character = newCharacter
            });
        }
    }

    public Character GetCharacter(int teamNumber)
    {
        foreach (Character character in characterList)
        {
            if (character.Team == teamNumber)
                return character;
        }
        return null;
    }

    public Character GetCharacter(int teamNumberToGet, int indexToGet)
    {
        int index = 0;
        foreach (Character character in characterList)
        {
            if (character.Team == teamNumberToGet)
            {
                if (index == indexToGet)
                    return character;
                index++;
            }     
        }
        return null;
    }
}

public class OnTeamMemberCreatedEventArgs : EventArgs
{
    public Character character;
}
