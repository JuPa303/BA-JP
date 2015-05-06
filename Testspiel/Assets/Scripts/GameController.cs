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
        if (systemNumber == 0)
        {
            //Debug.Log("Eyetracker");
            //clues = GameObject.Find("Clues");
            //clues.SetActive(true);
            //eyeTracker = GameObject.FindGameObjectWithTag("GazeController");
            //eyeTracker.SetActive(true);
            Camera.main.GetComponent<HighlightController>().enabled = true;
            //just Eye tracker scripts are enabled

        
        }

        if (systemNumber == 1)
        {
            //Debug.Log("Minimap");
            mapCamera = GameObject.FindGameObjectWithTag("MapCamera");
            //Debug.Log("get component" + mapCamera.GetComponent<MapCamera>().showMap);
            mapCamera.GetComponent<MapCamera>().showMap = true;
            //mapCamera.SetActive(true);

            //mini map scripts are enabled
        }

        if (systemNumber == 2)
        {
            //Debug.Log("Compass");
            //just compass scripts are enabled
        }



    }


}
