using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : TriggerArea
{

    public EndingTypes endingType;

    public bool requireFullWeight = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (requireFullWeight && FindObjectOfType<Hero>().currentSkills.Count > 4)
        {
            Invoke("DelayedEnding", 4f);
        }
        else if (!requireFullWeight)
        {
            Debug.Log("Skills: " + FindObjectOfType<Hero>().currentSkills.Count);
            if (endingType == EndingTypes.Princess && FindObjectOfType<Hero>().currentSkills.Count > 2)
            {
                endingType = EndingTypes.PrincessNoEquipment;
            }
            GameManager.LoadEnding(endingType);
        }
    }

    void DelayedEnding()
    {
        GameManager.LoadEnding(endingType);
    }

}
