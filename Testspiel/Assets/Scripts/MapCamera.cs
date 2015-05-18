using UnityEngine;
using System.Collections;

public class MapCamera : MonoBehaviour
{

    public bool showMap;
    // Use this for initialization
    void Start()
    {

        showMap = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (showMap == true)
        {

            gameObject.GetComponent<Camera>().enabled = true;
            gameObject.GetComponent<Camera>().pixelRect = new Rect(Screen.width - 250, 50, 200, 200);

        }

        else
        {
            gameObject.GetComponent<Camera>().enabled = false;

        }
    }
}
