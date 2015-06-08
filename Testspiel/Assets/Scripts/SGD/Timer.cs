﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private GameObject calibrationScreen;
    private GameObject player;
    private int counter = 5;
    public Text counterText;


    //calibration screen will appear
    void Start()
    {

        calibrationScreen = GameObject.FindGameObjectWithTag("Calibration");
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<FirstPersonController>().enabled = false;

        counterText.text = "" + counter;
        StartCoroutine(countdown());


    }

    //counts down from 5 to 1
    IEnumerator countdown()
    {
        while (counter > 0)
        {
            counterText.text = counter.ToString();
            yield return new WaitForSeconds(1);



            counter -= 1;
            counterText.text = counter.ToString();
            //Debug.Log(counter);
        }


        calibrationScreen.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<EyeTrackerData>().isChosen = true;
    }
}

