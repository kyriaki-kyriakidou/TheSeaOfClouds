using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeteTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject BGPrefab;
    bool enemyCreated = false;
    bool BGCreated = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemyCreated)
        {
            Instantiate(enemyPrefab);
            enemyCreated = true;
            Instantiate(enemyPrefab2);
            enemyCreated = true;

        }
        if (!BGCreated)
        {
            Instantiate(BGPrefab);
            BGCreated = true;
        }
    }
}
