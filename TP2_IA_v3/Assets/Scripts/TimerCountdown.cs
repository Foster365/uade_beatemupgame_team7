﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft = 180;
    public bool takingAway = false;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "";
    }

    private void Update()
    {
        if(takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft > 59) {

            if (secondsLeft % 60 > 9)
            {
                textDisplay.GetComponent<Text>().text = "0" + secondsLeft / 60 + ":" + secondsLeft % 60;
            }
            else
            {
                textDisplay.GetComponent<Text>().text = "0" + secondsLeft / 60 + ":0" + secondsLeft % 60;
            }
            
        }
        else if (secondsLeft > 10)
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        
        takingAway = false;
    }
}
