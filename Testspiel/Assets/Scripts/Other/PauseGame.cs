using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{
    /*
     * If the player hits ESC during the gameplay, the game pauses and he is asked if he wants to return to the game or go back to the main menu.  
     */
    private bool showWindow;
    private GameObject pauseMenue;
    private GameObject player;
    private GameObject eyeTrackerController;


    // Use this for initialization
    void Start()
    {

        pauseMenue = GameObject.FindGameObjectWithTag("PauseMenue");
        player = GameObject.FindGameObjectWithTag("Player");
        eyeTrackerController = GameObject.FindGameObjectWithTag("GazeController");
        pauseMenue.SetActive(false);
    }

    // If the user presses ESC, the window will appear and the cursor can be used.
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenue.SetActive(true);
            player.GetComponent<FirstPersonController>().enabled = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //returning to the main menu
    public void backToMainMenu()
    {
        Application.LoadLevel("Start");
    }


    //if canceled, returning to the scene, cursor is locked and invisible, window disappears
    public void cancel()
    {
        pauseMenue.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
