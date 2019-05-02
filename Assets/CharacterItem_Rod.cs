using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItem_Rod : CharacterItem
{

    protected override void OnWithdraw()
    {
        Invoke("GoFishing", 1f);
    }

    void GoFishing()
    {
        GameManager.LoadEnding(EndingTypes.Fishing);
    }

}
