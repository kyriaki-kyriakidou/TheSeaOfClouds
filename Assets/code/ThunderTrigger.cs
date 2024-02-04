using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    float timer = 50;
    bool enemyCreated = false;

    void Start()
    {
    
    
    }
        void Update()
    {
        timer = timer - 10;
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemyCreated)
        {
            Instantiate(enemyPrefab);
            enemyCreated = true;
        }
        if (timer < 0)
        {
            enemyPrefab.SetActive(false);
        }
    }
}
