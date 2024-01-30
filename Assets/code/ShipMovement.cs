using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float speed2 = 0.6f;
    Rigidbody2D rb;
    // Start is called before the first frame update

    public int maxHealth = 100;
    public int currentHealth;
    public newsc healthBar;

    public int maxscore = 100;
    public int currentscore;
    public Score scorebar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //health
        currentHealth = maxHealth;
        healthBar.setmaxhealth(maxHealth);

        //score
        currentscore = maxscore;
        scorebar.setmaxscore(maxscore);
    }

    void Update()
    {
        if (GameManager.instance.myState != GameManager.State.playing) return;
        { 
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed2 * Time.deltaTime, 0);
       
            
            if (transform.position.x > 12f)
        {
            Vector3 v = transform.position;
            v.x = -10.35f;
            transform.position = v;
        }

        if (transform.position.x < -11f)
        {
            Vector3 v = transform.position;
            v.x = 11f;
            transform.position = v;
        }

        if (transform.position.y > 5f)
        {
            Vector3 v = transform.position;
            v.y = 5f;
            transform.position = v;
        }

        if (transform.position.y < -2.6f)
        {
            Vector3 v = transform.position;
            v.y = -2.6f;
            transform.position = v;
        }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            GiveScore(10);

        }

        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }

    }

    void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        healthBar.sethealth(currentHealth);
    }

    void GiveScore(int score)
    {
        currentscore -= score;
        scorebar.setscore(currentscore);
    }
}
