using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : TriggerArea
{

    public EndingTypes endingType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.LoadEnding(endingType);
    }

}
