using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private int playerTeamNumberOfCharacter;
    [SerializeField] private int AITeamNumberOfCharacter;


    void Start()
    {
        CreateTeamMember(0, playerTeamNumberOfCharacter);
        CreateTeamMember(1, AITeamNumberOfCharacter);
    }

    private void CreateTeamMember(int team, int memberInTeam)
    {
        for (int index = 0; index < memberInTeam; index++)
        {
            GameObject newTeamMemberGO = Instantiate(characterPrefab, this.transform);
            newTeamMemberGO.GetComponent<Character>().Name = Random.Range(1, 100).ToString();
            newTeamMemberGO.name = newTeamMemberGO.GetComponent<Character>().Name + "_" + team;
        }
    }
}
