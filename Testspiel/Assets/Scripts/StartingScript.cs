﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartingScript : MonoBehaviour
{

    private Button playButton;
    //private bool nothingToggled = true;
    private GameObject menue;
    private GameObject player;
    private GameObject eyeTracker;
    private GameObject clues;
    private GameObject gameControlObj;
    private GameObject compass;
    private int system = 3;
    private FirstPersonController firstpersoncontroller;





    // Use this for initialization
    void Start()
    {
        
        getComponents();
        setScriptsDisabled();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void getComponents()
    {
        menue = GameObject.Find("Menu");
        gameControlObj = GameObject.Find("GameControl");
        player = GameObject.FindGameObjectWithTag("Player");
        eyeTracker = GameObject.FindGameObjectWithTag("GazeController");
        compass = GameObject.FindGameObjectWithTag("Compass");

        firstpersoncontroller = player.GetComponent<FirstPersonController>();

    }

    //disable scripts for not interfering with the starting screen
    private void setScriptsDisabled()
    {
        Camera.main.GetComponent<HighlightController>().enabled = false;
        firstpersoncontroller.enabled = false;
        //clues.SetActive(false);
        //eyeTracker.SetActive(false);
        compass.SetActive(false);
    }


    //get the number from toggle buttons
    public void setSystem(int sysNumber)
    {

        system = sysNumber;


    }


    //if button "Play!" is pressed, the system number will be delivered to the game controller
    public void pressStart()
    {
        if (system != 3)
        {

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            gameControlObj.GetComponent<GameController>().systemNumber = system;


            firstpersoncontroller.enabled = true;


            if (system == 0)
            {
                menue.SetActive(false);
                eyeTracker.SetActive(true);
                player.GetComponent<EyeTrackerData>().isChosen = true;

            }
            else if (system == 1)
            {
                Application.LoadLevel("MiniMap");
            }


            else if (system == 2)
            {
                Application.LoadLevel("Compass");

                //menue.SetActive(false);
                //compass.SetActive(true);
                //compass.GetComponent<Compass>().isChosen = true;

            }
            else
            {
                menue.SetActive(false);
            }




        }

    }

    void OnGui()
    {


    }
}
