using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Team { get => team ; set => team = value ; }
    private int team;

    public string Name { get => name; set => name = value; }
    private new string name;


    private void OnEnable() 
    {
        PlayerController.current.OnDisplayCharacter += HandleDisplayOnConsole; 
    }

    private void OnDisable() 
    {
        PlayerController.current.OnDisplayCharacter -= HandleDisplayOnConsole; 
    }

    public void HandleDisplayOnConsole(object sender, System.EventArgs e)
    {
        Debug.Log("name: " + name + " - team: " + team);
    }    
}
