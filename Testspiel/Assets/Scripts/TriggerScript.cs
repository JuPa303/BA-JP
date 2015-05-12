using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour
{

    private GameObject compass;
    
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
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        
        if(collider.tag == "Player")
        {
            countSameTrigger++;
            Debug.Log("count " + countSameTrigger);
            if ((countSameTrigger%2) == 0)
            {
                Debug.Log("wrong direction");
                decreaseCounter();             
             
            }
            
            //showing new target
            //if it is not the same collider as the one triggered before, then set the next one as target (user is not turning around)
            //no counting up
            else
            {
                Debug.Log("right direction");
                increaseCounter();
                
                
            }
           
           compassScript.target = GameObject.Find("RoomTrigger" + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID);
           Debug.Log("target" + compassScript.target);
        }
    }




    private void increaseCounter()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID++;
    }

    private void decreaseCounter()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().triggerID--;
    }

        //soll sagen, dass raum betreten wurde(sgd)

        //Eyetrackerdata start: wait 4s: liegt auf player -> nur einmal aufgerufen, sollte vor jedem neuen raum warten, bei getgazes?? bool setzen 

}
