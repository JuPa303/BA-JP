using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompassEnd : MonoBehaviour {


    private int system = 3;
    private GameObject end;
    private GameObject player;
    private GameObject data;
    private GameObject compass;
    private GameObject coins;
    public Text counter;

    // Use this for initialization
    void Start()
    {
        end = GameObject.FindGameObjectWithTag("End");
        player = GameObject.FindGameObjectWithTag("Player");
        end.SetActive(false);
        data = GameObject.FindGameObjectWithTag("Data");
        compass = GameObject.FindGameObjectWithTag("Compass");
        coins = GameObject.FindGameObjectWithTag("Coins");
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
    private void OnTriggerEnter(Collider collider)
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        end.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        data.GetComponent<TimeKeeper>().TimerIsRunning = false;

        data.GetComponent<Filewriter>().gazeTimeCounter = compass.GetComponent<Compass>().CompassGazeTimer;


        counter.text = "" + coins.GetComponent<CoinCounter>().counter;



    }

    public void pressOkay()
    {
        if (system != 3)
        {
            if (system == 0)
            {
                Application.LoadLevel("MiniMap");
            }

            if (system == 1)
            {
                Application.LoadLevel("SGD");
            }

            if (system == 2)
            {
                Application.Quit();
            }
        }

    }
}