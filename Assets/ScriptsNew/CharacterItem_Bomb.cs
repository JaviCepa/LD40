using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItem_Bomb : CharacterItem
{

    public GameObject bombPrefab;

    bool isNextToBomb;

    public BoxCollider2D box;

    bool isWithdrawed = false;

    private void Update()
    {
        box.enabled = isWithdrawed;
    }

    protected override void OnWithdraw()
    {
        isWithdrawed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BombArea")
        {
            isNextToBomb = true;
            PlaceBomb();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNextToBomb = false;
    }

    protected override void OnUse(Object data)
    {
        //Dont do anything
    }

    void PlaceBomb()
    {
        if (isNextToBomb)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }
    }

}
