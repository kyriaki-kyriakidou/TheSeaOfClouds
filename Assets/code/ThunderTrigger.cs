using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThunderTrigger : MonoBehaviour
{
    /*public GameObject enemyPrefab;
    float timer = 50;
    bool enemyCreated = false;*/

    //rain animation
    [Header("Custom Event")]
    public UnityEvent myEvent;
    [Header("Custom Event")]
    public UnityEvent myEvent2;
    //rain animation
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (myEvent2 == null)
        {
            print("GeteTrigger was triggered but myEvent was null");
        }
        else
        {
            print("GeteTrigger Activated.Triggered" + myEvent2);
            myEvent2.Invoke();
        }

        if (myEvent == null)
        {
            print("GeteTrigger was triggered but myEvent was null");
        }
        else
        {
            print("GeteTrigger Activated.Triggered" + myEvent);
            myEvent.Invoke();
        }

    }

   /* void Start()
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
    }*/
}
