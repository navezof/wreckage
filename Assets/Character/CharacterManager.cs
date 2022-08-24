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

    public EventHandler<OnTeamMemberCreatedEventArgs> OnTeamMemberCreated;

    void Start()
    {
        CreateTeamMember(0, playerTeamNumberOfCharacter);
        CreateTeamMember(1, AITeamNumberOfCharacter);
    }

    private void CreateTeamMember(int team, int memberInTeam)
    {
        Character newCharacter = null;

        for (int index = 0; index < memberInTeam; index++)
        {
            GameObject newTeamMemberGO = Instantiate(characterPrefab, this.transform);
            newCharacter = newTeamMemberGO.GetComponent<Character>();
            newCharacter.Name = UnityEngine.Random.Range(1, 100).ToString();
            newTeamMemberGO.name = newTeamMemberGO.GetComponent<Character>().Name + "_" + team;

            OnTeamMemberCreated?.Invoke(this, new OnTeamMemberCreatedEventArgs
            {
                character = newCharacter
            });
        }
    }
}

public class OnTeamMemberCreatedEventArgs : EventArgs
{
    public Character character;
}
