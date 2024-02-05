using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowThirdBg : MonoBehaviour
{

    public GameObject enemyRef;
    public GameObject BGPrefab;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ShipMovement>() == null) return;

        Instantiate(BGPrefab);
        enemyRef.SetActive(true);

        gameObject.SetActive(false);
    }
}
