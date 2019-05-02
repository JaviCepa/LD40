using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawnPoint : MonoBehaviour
{
#if UNITY_EDITOR
    void Start()
    {
        var hero = FindObjectOfType<Hero>();
        hero.transform.position = new Vector3(transform.position.x, transform.position.y, hero.transform.position.z);
    }
#endif

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
