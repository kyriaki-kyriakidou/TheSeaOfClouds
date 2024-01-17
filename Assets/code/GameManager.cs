using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI messagesTxt;
    int score = 0;
    float time = 30;

    public static GameManager instance;

    public enum State { stopped, playing, paused }
    public State myState;

    void Start()
    {
        instance = this;
        myState = State.stopped;
    }

    // Update is called once per frame
    void Update()
    {
        switch (myState)
        {
            case State.stopped:
                messagesTxt.text = "press fire to start dreaming";
                if (Input.GetButtonDown("Fire1"))
                {
                    myState = State.playing;
                    time = 30;
                    messagesTxt.text = "";
                }
                break;
            case State.playing:
                time -= Time.deltaTime;
               
                if (time < 0)
                {
                    myState = State.stopped;
                    messagesTxt.text = "Game Over wake up! Press Fire to dream again";
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
        }
    }

    public void IncreaseScore(int inc)
    {
        score += inc;
        
    }
}
