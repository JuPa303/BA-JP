using UnityEngine;
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
        //clues = GameObject.Find("Clues");
        firstpersoncontroller = player.GetComponent<FirstPersonController>();

    }

    //disable scripts for not interfering with the starting screen
    private void setScriptsDisabled()
    {
        Camera.main.GetComponent<HighlightController>().enabled = false;
        firstpersoncontroller.enabled = false;
        //clues.SetActive(false);
        eyeTracker.SetActive(false);
    }


    //get the number from toggle buttons
    public void setSystem(int sysNumber)
    {

        Debug.Log("sysNumber" + sysNumber);
        system = sysNumber;


    }


    //if button "Play!" is pressed, the system number will be delivered to the game controller
    public void pressStart()
    {
        if (system != 3)
        {

            gameControlObj.GetComponent<GameController>().systemNumber = system;


            firstpersoncontroller.enabled = true;


            if (system == 0)
            {
                eyeTracker.SetActive(true);
            }

            menue.SetActive(false);

            // one system has to be toggled
            //if (system != 3)
            //{
            //    menue.SetActive(false);
            //    firstpersoncontroller.enabled = true;

            //}
            //else{
            // do nothing
            //}

        }

    }

    void OnGui()
    {


    }
}
