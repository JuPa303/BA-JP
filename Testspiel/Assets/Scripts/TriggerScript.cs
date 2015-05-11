using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour
{

    private GameObject compass;
    private int counter = 0;
    private int countSameTrigger = 0;
    private string currentCollider = "Start";
    private string nextCollider;
    private bool scriptEnabled;

    EyeTrackerData eyetrackerScript;
    Compass compassScript;


    // Use this for initialization
    void Start()
    {
        eyetrackerScript = GetComponent<EyeTrackerData>();
        compass = GameObject.FindGameObjectWithTag("Compass");
        compassScript = compass.GetComponent<Compass>();

        Debug.Log("target1 " + compassScript.target);




    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("target1 " + compassScript.target);

        //if the collider is no clue
        if (collider.tag != "Clue")
        {
            //counter++;
            Debug.Log("current" + currentCollider);

            //if the current one is empty at the beginning, set the one triggered as current
            //if (currentCollider == "")
            //{
            //    currentCollider = collider.transform.name;
            //}

            //user turned around, took the same trigger twice
            if (collider.transform.name.Equals(currentCollider))
            {
                countSameTrigger++;
                Debug.Log("same trigger");

                //showing old target again (user in wrong direction, has to turn around and go through trigger again
                if (countSameTrigger % 2 == 1)
                {
                    Debug.Log("wrong direction");
                    counter--;
                    compassScript.target = GameObject.Find(getNextCollider());
                }

                 //showing new target
                //if it is not the same collider as the one triggered before, then set the next one as target (user is not turning around)
                //no counting up
                else
                {
                    Debug.Log("right direction");
                    counter++;
                    compassScript.target = GameObject.Find(getNextCollider());
                }
                //Debug.Log("currentCollider1 " + currentCollider);
                Debug.Log("target " + compassScript.target);


                //counter++;
            }

            //if user is going through trigger 
            else
            {
                counter++;
                Debug.Log("counter" + counter);
                Debug.Log("nextCollider " + getNextCollider());
                compassScript.target = GameObject.Find(getNextCollider());


                
            }
            // Debug.Log("currentCollider2 " + currentCollider);


        }
        

        //soll sagen, dass raum betreten wurde(sgd)
       
        //Eyetrackerdata start: wait 4s: liegt auf player -> nur einmal aufgerufen, sollte vor jedem neuen raum warten, bei getgazes?? bool setzen 

    }

    private string getNextCollider()
    {

        nextCollider = "RoomTrigger" + counter;
        Debug.Log("nextCollider " + nextCollider);
        Debug.Log("count" + counter);
        return nextCollider;
    }
}
