using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeteTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject BGPrefab;
    bool enemyCreated = false;
    bool BGCreated = false;
    //rain animation
    [Header("Custom Event")]
    public UnityEvent myEvent;


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


        if(myEvent==null)
        {
            print("GeteTrigger was triggered but myEvent was null");
        }
        else
        {
            print("GeteTrigger Activated.Triggered" + myEvent);
            myEvent.Invoke();
        }
    }
}
