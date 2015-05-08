using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    private GameObject eyeTracker;
    private GameObject clues;
    private GameObject mapCamera;


    public int systemNumber = 4;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        enableSpecificScripts();
    }


    //only scripts are enabled which are needed for their version of the game
    private void enableSpecificScripts()
    {
        //just Eye tracker scripts are enabled
        if (systemNumber == 0)
        {
            Camera.main.GetComponent<HighlightController>().enabled = true;
        }

        //mini map scripts are enabled
        if (systemNumber == 1)
        {
            mapCamera = GameObject.FindGameObjectWithTag("MapCamera");
            mapCamera.GetComponent<MapCamera>().showMap = true;
        }

        //just compass scripts are enabled
        if (systemNumber == 2)
        {
            //Debug.Log("Compass");

        }



    }


}
