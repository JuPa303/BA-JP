using UnityEngine;
using System.Collections;

public class TimeKeeper : MonoBehaviour
{

    private float levelTimer = 0.0f;
    public bool TimerIsRunning = false;
    private bool dataSent = false;
    private string endTime = "";

    private void Start()
    {
        TimerIsRunning = true;
       
    }

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
