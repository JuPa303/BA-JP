using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    private GameObject systemMenue;
    private GameObject mainMenue;
    private GameObject controlMenue;


	// Use this for initialization
	void Start () {
        Debug.Log("Start");
        systemMenue = GameObject.Find("StartScreen");
        mainMenue = GameObject.FindGameObjectWithTag("MainMenue");
        controlMenue = GameObject.FindGameObjectWithTag("ControlMenue");
        systemMenue.SetActive(false);
        controlMenue.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
     
	}


    public void chooseSystem()
    {
        
        systemMenue.SetActive(true);
        mainMenue.SetActive(false);
    }

    public void backToMainMenue()
    {
        controlMenue.SetActive(false);
        mainMenue.SetActive(true);
    }

    public void showControls()
    {
        controlMenue.SetActive(true);
        mainMenue.SetActive(false);
    }
}

