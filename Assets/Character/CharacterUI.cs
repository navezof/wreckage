using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text characterName;

    private Character character;

    public Character Character { get => character; }

    public void LinkWithData(Character character)
    {
        this.character = character;
        
        characterName.text = character.name;
    }
    
}
