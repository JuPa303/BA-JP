using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using iView;

public class ChooseSystem : MonoBehaviour
{

    private Button playButton;

    private GameObject menue;
    private GameObject player;
    private GameObject eyeTracker;
    private GameObject clues;
    private GameObject gameControlObj;
    private GameObject compass;
    private GameObject timer;
    private GameObject calibrationScreen;

    private int system = 3;
    int calibrationType = 5;

    private FirstPersonController firstpersoncontroller;

    private bool didCalibration = false;



    // Use this for initialization
    void Start()
    {

        getComponents();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void getComponents()
    {
        menue = GameObject.Find("StartScreen");
        gameControlObj = GameObject.Find("GameControl");

    }


    //get the number from toggle buttons
    public void setSystem(int sysNumber)
    {

        system = sysNumber;

    }


    //if button "Play!" is pressed, the system number will be delivered to the game controller
    public void pressStart()
    {

        calibrateET();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (system != 3)
        {


            if (system == 0)
            {

                Application.LoadLevel("SGD");


            }
            else if (system == 1)
            {
                Application.LoadLevel("MiniMap");
            }


            else if (system == 2)
            {
                Application.LoadLevel("Compass");

            }
            else
            {
                menue.SetActive(false);
            }

        }

    }

    private void calibrateET()
    {
        if (didCalibration == false)
        {

            SMIGazeController.Instance.StartCalibration(calibrationType);
            didCalibration = true;

        }

    }

    void OnGui()
    {


    }
}
