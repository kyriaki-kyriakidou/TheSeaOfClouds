using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCloud : MonoBehaviour
{
    public int health;
    public GameManager gameManager;

    public float speed = 3;
    public float attackSpeed = 4;
    public float limit = 4;
    public float distanceToAttack;
    public Transform ship;
    enum State { patrol, attack }
    State myState = State.patrol;

    void Update()
    {
        switch (myState)
        {
            case State.patrol:
                transform.Translate(0, speed * Time.deltaTime, 0);
                if (transform.position.y > limit && speed > 0)
                {
                    speed = -speed;
                }
                if (transform.position.y < -limit && speed < 0)
                {
                    speed = -speed;
                }
                if (Vector3.Distance(transform.position, ship.position) < distanceToAttack)
                {
                    myState = State.attack;
                }
                break;
            case State.attack:
                transform.position =
                    Vector3.MoveTowards(transform.position,
                        ship.position, attackSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, ship.position) > 6)
                {
                    myState = State.patrol;
                }
                break;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<RainbowBall>() != null)
        {
            health -= collision.gameObject.GetComponent<RainbowBall>().damage;

            if (health <= 0)
            {
                gameManager.myState = GameManager.State.gameWon;
                Destroy(gameObject);
            }
        }
    }
}
