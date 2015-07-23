using UnityEngine;
using System.Collections;

public class TimeKeeper : MonoBehaviour
{
    /*
     * This keeps the time which is needed by every user until he reaches the end of each level.
     */
    private float levelTimer = 0.0f;
    public bool TimerIsRunning = false;
    private bool dataSent = false;
    private string endTime = "";

    private void Start()
    {
        TimerIsRunning = true;

    }

    // the time is updated every frame. if the player reaches the end, the time will be stopped.
    private void Update()
    {

        if (TimerIsRunning == true)
        {
            levelTimer += Time.deltaTime * 1;
        }
        else
        {
            sendData();
        }
    }

    //The data is handed over to the filewriter 
    private void sendData()
    {
        if (dataSent == false)
        {
            endTime = levelTimer.ToString("f2");
            this.gameObject.GetComponent<Filewriter>().time = endTime;
            this.gameObject.GetComponent<Filewriter>().countingEnds = true;
            dataSent = true;
        }
    }

}
