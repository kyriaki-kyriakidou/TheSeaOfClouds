using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeteTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    bool enemyCreated = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemyCreated)
        {
            Instantiate(enemyPrefab);
            enemyCreated = true;
        }
    }
}
