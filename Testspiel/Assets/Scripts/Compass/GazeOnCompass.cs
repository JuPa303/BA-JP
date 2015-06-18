using UnityEngine;
using System.Collections;
using iView;

public class GazeOnCompass : MonoBehaviour {

    public int gazeCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void OnGazeEnter()
    {
        gazeCounter++;
    }
}
