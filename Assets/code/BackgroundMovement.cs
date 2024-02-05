using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float movementSpeed = -0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.myState != GameManager.State.playing) return;
        transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
    }
}
