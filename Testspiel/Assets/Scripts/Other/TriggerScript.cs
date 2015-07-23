using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour
{
    /*
     * This script is for managing the triggers and if the player entered one room twice.
     */
    private GameObject compass;

    private string nextCollider;
    private bool scriptEnabled;

    EyeTrackerData eyetrackerScript;

    Compass compassScript;

    private int ID;
    private int countSameTrigger = 0;



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
            countSameTrigger++;


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

        }
    }

    //The counter will be increased if the player has not found every room
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

    //The counter will be decreased if the player goes back in the same room
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
