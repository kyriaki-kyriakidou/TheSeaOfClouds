using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThunderTrigger : MonoBehaviour
{


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


}
