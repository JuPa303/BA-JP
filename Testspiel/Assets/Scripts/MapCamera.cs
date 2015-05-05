using UnityEngine;
using System.Collections;

public class MapCamera : MonoBehaviour {

    public bool showMap;
	// Use this for initialization
	void Start () {
	
        showMap = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (showMap == true)
        {
            Debug.Log("show map true");
            //Camera..enabled = true;
            //enabled = true;
            gameObject.GetComponent<Camera>().enabled = true;

        }

        else
        {
            Debug.Log("show map false");
            gameObject.GetComponent<Camera>().enabled = false;
            //Camera.this.enabled = false;
          //enabled = false;
        }
	}
}
