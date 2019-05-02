using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explosionParticles;

    public void Explode()
    {
        foreach (var item in Physics2D.OverlapCircleAll(transform.position, 1.5f))
        {
            if (item.gameObject.name == "Boulder" || item.gameObject.name == "BombArea")
            {
                Destroy(item.gameObject);
            }
        }

        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
