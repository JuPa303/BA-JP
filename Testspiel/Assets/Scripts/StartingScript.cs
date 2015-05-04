using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartingScript : MonoBehaviour {

    private Button playButton;
    private bool nothingToggled = true;
    private GameObject menue;
    


	// Use this for initialization
	void Start () {
        menue = GameObject.Find("Menu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void pressStart()
    {
        menue.SetActive(false);

    }
    void OnGui()
    {


    }
}
