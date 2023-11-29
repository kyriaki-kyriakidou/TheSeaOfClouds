using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicShip : MonoBehaviour
{
    public float acc = 8;
    public float jumpSpeed = 10;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rb.velocity += new Vector2(0, jumpSpeed);
        }
    }
    void FixedUpdate()
    {
        rb.velocity += new Vector2(
        Input.GetAxis("Horizontal") * acc * Time.fixedDeltaTime, 0);
        if (transform.position.x > 10.35f)
        {
            Vector3 v = transform.position;
            v.x = 10.35f;
            transform.position = v;
        }

        if (transform.position.x < -9.8f)
        {
            Vector3 v = transform.position;
            v.x = -9.8f;
            transform.position = v;
        }
    }
}
