using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI messagesTxt;

    public ShipMovement shipMovement;

    public GameObject gameWinImage;
    public GameObject tutorialImage;
    
    float time = 100;
/*    //scoretimer
    public Score scoretimer;
    public int maxscore = 100;
    public int currentscore;*/


    public static GameManager instance;

    public enum State { stopped, playing, paused, gameOver, gameWon }
    public State myState;

    void Start()
    {
        instance = this;
        myState = State.stopped;

        
/*        //score
        currentscore = maxscore;
        scoretimer.setmaxscore(maxscore);*/
    }

    // Update is called once per frame
    void Update()
    {
        switch (myState)
        {
            case State.stopped:
                messagesTxt.text = "press fire to start dreaming";
                tutorialImage.SetActive(true);
                if (Input.GetButtonDown("Fire1"))
                {
                    myState = State.playing;
                    
                    messagesTxt.text = "";
                    time = 100;

                    tutorialImage.SetActive(false);
                }
                break;
            case State.playing:
                time -= Time.deltaTime;
                //GiveScore(time);
                if (shipMovement.currentscore <= 0 || shipMovement.currentHealth <= 0)
                {
                    myState = State.gameOver;
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    myState = State.paused;
                    messagesTxt.text = "Paused: press P to continue";
                }
                break;
            case State.paused:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    myState = State.playing;
                    messagesTxt.text = "";

                }
                break;
            case State.gameOver:
                messagesTxt.text = "Game Over wake up! Press Fire to dream again";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                    //myState = State.playing;
                    //messagesTxt.text = "";

                }
                break;
            case State.gameWon:
                //Show Image
                gameWinImage.SetActive(true);
                break;
        }
    }

/*    public void GiveScore(int score)
    {
        currentscore = score;
        scoretimer.setscore(currentscore);
    }*/
}
