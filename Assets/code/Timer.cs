using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float duration;
    Action onComplete;

    bool isCounting;

    void Update()
    {
        if (isCounting)
        {
            duration -= Time.deltaTime;

            if (duration <= 0f) OnTimerComplete();
        }
    }

    public void StartTimer(float time, Action action)
    {
        isCounting = true;
        duration = time;
        onComplete = action;
    }

    public void OnTimerComplete()
    {
        isCounting = false;
        duration = 0f;

        if (onComplete == null) return;

        onComplete.Invoke();

        onComplete = null;
    }
}
