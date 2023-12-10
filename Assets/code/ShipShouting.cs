using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShouting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireSpeed = 10;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bulletPrefab,
            spawnPoint.position, spawnPoint.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.velocity += (Vector2)transform.right * fireSpeed;
        }
    }
}
