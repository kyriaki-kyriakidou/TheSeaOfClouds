using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Slider slider2;
    public void setmaxscore(int score)
    {
        slider2.maxValue = score;
        slider2.value = score;

    }

    public void setscore(int score)
    {
        slider2.value = score;


    }
}
