using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public GameManager gameManager;

    public float speed = 0.5f;
    public float speed2 = 0.6f;
    Rigidbody2D rb;
    // Start is called before the first frame update

    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    public newsc healthBar;

    [Header("Score")]
    public int maxscore = 100;
    public int currentscore;
    public float scoreSubtractionDelay;
    public Score scorebar;
    /*  //gamemanager
      public static ShipMovement instance;*/
    //sield
    private bool shielded;
    bool hasShield;
    public Animator shieldAnimator;
    [SerializeField]
    private GameObject shield;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //health
        currentHealth = maxHealth;
        healthBar.setmaxhealth(maxHealth);

        //score
        currentscore = maxscore;
        scorebar.setmaxscore(maxscore);

        /*        //gamemanager
                instance = this;*/
        //shield
        shielded = false;

        StartCoroutine(ScoreTimer());
    }

    void Update()
    {
        if (GameManager.instance.myState != GameManager.State.playing) return;
        { 
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed2 * Time.deltaTime, 0);
       
            
            if (transform.position.x > 6f)
        {
            Vector3 v = transform.position;
            v.x = -11f;
            transform.position = v;
        }

        if (transform.position.x < -12f)
        {
            Vector3 v = transform.position;
            v.x = 5f;
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

        //timer
        //Scoretimer(1);
        

        //shield
        CheckShield();
    }

    IEnumerator ScoreTimer()
    {
        while (currentscore > 0)
        {            
            if (gameManager.myState == GameManager.State.playing)
            {
                currentscore -= 1;

                scorebar.setscore(currentscore);

                yield return new WaitForSeconds(scoreSubtractionDelay);
            }

            yield return null;
        }
    }

    void CheckShield()
    {
        if (Input.GetKey(KeyCode.Space) && !shielded && hasShield)
        {
            shield.SetActive(true);
            shielded = true;
            //code for turning off the shield
            Invoke("Noshield", 3f);

            shieldAnimator.enabled = true;
        }
    }

    void Noshield()
    {
        shield.SetActive(false);
        shielded = false;
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
            if (!shielded)
            {
                if (GameManager.instance.myState != GameManager.State.playing) return;
                TakeDamage(5);
            }
            
        }

        if (collision.gameObject.tag == "Shield")
        {
            hasShield = true;
            Destroy(collision.gameObject);


        }

    }

    void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        healthBar.sethealth(currentHealth);
    }

    public void GiveScore(int score)
    {
        currentscore += score;
        scorebar.setscore(currentscore);
      
    }

    public void Scoretimer(int timer)
    {
        currentscore -= timer;
        scorebar.setscore(currentscore);
       
    }
}
