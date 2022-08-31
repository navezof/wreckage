using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject characterUIPrefab;
    [SerializeField] private CharacterManager characterManager;
    
    public void Start()
    {
        foreach (GameObject gameObject in characterManager.CharacterList)
        {
            GameObject newCharacterUI = Instantiate(characterUIPrefab, this.transform);
            newCharacterUI.GetComponent<CharacterUI>()?.Initialize(gameObject);
        }
    }
}
