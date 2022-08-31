using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUI : BaseUI
{
    protected override void UpdateText()
    {
        text.text = data.GetComponent<CombatProfileManager>().CombatProfile.Name;
    }
}
