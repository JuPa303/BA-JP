using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    /*
     *  This controls the whole starting scene, which gui texts are apppearing and disappearing. 
     */
      
    private GameObject systemMenue;
    private GameObject mainMenue;
    private GameObject controlMenue;


    // Use this for initialization
    void Start()
    {

        systemMenue = GameObject.Find("StartScreen");
        mainMenue = GameObject.FindGameObjectWithTag("MainMenue");
        controlMenue = GameObject.FindGameObjectWithTag("ControlMenue");

        systemMenue.SetActive(false);
        controlMenue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //the choosing-system window will be displayed
    public void chooseSystem()
    {

        systemMenue.SetActive(true);
        mainMenue.SetActive(false);
    }

    //getting back to the main menu
    public void backToMainMenu()
    {
        controlMenue.SetActive(false);
        mainMenue.SetActive(true);
    }

    //shows all the controls the player can use
    public void showControls()
    {
        controlMenue.SetActive(true);
        mainMenue.SetActive(false);
    }

    //loads the testing scene
    public void testControls()
    {
        Application.LoadLevel("Testumgebung");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}

