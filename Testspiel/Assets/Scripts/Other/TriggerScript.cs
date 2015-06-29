using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour
{

    private GameObject compass;

    private int countSameTrigger = 0;
    private string nextCollider;
    private bool scriptEnabled;

    EyeTrackerData eyetrackerScript;

    Compass compassScript;

    private int ID;



    // Use this for initialization
    void Start()
    {

        eyetrackerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<EyeTrackerData>();
        compass = GameObject.FindGameObjectWithTag("Compass");
      
        if (compass != null)
        {
            compassScript = compass.GetComponent<Compass>();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //if collider triggers something, compass will be set on a new target, sgd is supposed to wait 
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player")
        {

            // ID = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID;

            countSameTrigger++;
            //Debug.Log("count " + countSameTrigger);

            //if player touches same trigger more times, there is a counter which detects the direction of the player
            if ((countSameTrigger % 2) == 0)
            {
             
                decreaseCounter();

            }

            //showing new target
            //if it is not the same collider as the one triggered before, then set the next one as target (user is not turning around)
            //no counting up
            else
            {
                //Debug.Log("right direction");
                increaseCounter();

                if (eyetrackerScript != null)
                {
                    eyetrackerScript.hasToWait = true;

                }

            }

            if (compass != null)
            {
                compassScript.target = GameObject.Find("RoomTrigger" + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID);
            }
            //Debug.Log("target" + compassScript.target);
        }
    }




    private void increaseCounter()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID <= 5)
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID++;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID = 6;
        }

    }

    private void decreaseCounter()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID--;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID = 0;
        }

    }



}
