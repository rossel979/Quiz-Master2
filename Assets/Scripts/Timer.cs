using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{   
    [SerializeField] float flttimeToCompleteQuestion = 30f;
    [SerializeField] float flttimeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public float fillFraction;
    bool isAnsweringQuestion;
    float timerValue;
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / flttimeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = flttimeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / flttimeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = flttimeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
