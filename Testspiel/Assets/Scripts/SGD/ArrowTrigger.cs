using UnityEngine;
using System.Collections;

public class ArrowTrigger : MonoBehaviour
{
    HighlightController highContr;
    private int counter = 0;
    // Use this for initialization
    void Start()
    {
        highContr = Camera.main.GetComponent<HighlightController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player")
        {


            //counter++;
            ////Debug.Log("count " + countSameTrigger);

            ////if player touches same trigger more times, there is a counter which detects the direction of the player
            //if ((counter % 2) == 0)
            //{
            //    //wrong direction
            //    highContr.arrowIsKilled = true;

            //}

            ////showing new target
            ////if it is not the same collider as the one triggered before, then set the next one as target (user is not turning around)
            ////no counting up
            //else
            //{
            //    //Debug.Log("right direction");

            //    highContr.arrowIsKilled = false;
             

            //}

            highContr.arrowIsKilled = false;

        }
    }
}
