using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text characterName;

    private GameObject character;

    public GameObject Character { get => character; }

    public void LinkWithData(GameObject character)
    {
        this.character = character;
        
        characterName.text = character.GetComponent<CombatProfileManager>().GetName();
    }
    
}
