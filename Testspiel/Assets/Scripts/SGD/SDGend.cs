﻿using UnityEngine;
using System.Collections;

public class SDGend : MonoBehaviour
{
    //This shows an End Screen if the player has reached his final Destination. 
    //Now he can choose between doing the other two navigation systems or quitting the game.



    private int system = 3;
    private GameObject end;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        end = GameObject.FindGameObjectWithTag("EndSDG");
        player = GameObject.FindGameObjectWithTag("Player");
        end.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //get the number from toggle buttons
    public void setSystem(int sysNumber)
    {

        system = sysNumber;


    }

    //when user enters the last room
    private void OnTriggerEnter(Collider collider)
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        end.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;


    }

    public void pressOkay()
    {
        if (system != 3)
        {
            if (system == 0)
            {
                Application.LoadLevel("Compass");
            }

            if (system == 1)
            {
                Application.LoadLevel("MiniMap");
            }

            if (system == 2)
            {
                Application.Quit();
            }
        }

    }
}