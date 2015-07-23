using UnityEngine;
using System.Collections;
using iView;

public class GazeArea : GazeMonobehaviour
{
    /*
     * This is the actual counter of how often the user looks at the map. Also the time will be recorded.
     */

    public float mapGazeTimer = 0.0f;
    public bool isFocused = false;

    public int counter = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //If the gaze enteres the area, time will be added and the counter increased.
    public void OnGazeEnter()
    {

        if (!isFocused)
        {
            mapGazeTimer += Time.deltaTime * 1;
            counter++;
            isFocused = true;

        }
    }
}
