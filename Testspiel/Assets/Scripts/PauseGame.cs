using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{

    private bool showWindow;
    private GameObject pauseMenue;
    private GameObject player;

    // Use this for initialization
    void Start()
    {

        pauseMenue = GameObject.FindGameObjectWithTag("PauseMenue");
        player = GameObject.FindGameObjectWithTag("Player");
        pauseMenue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {

            Debug.Log("Pressed ESC");
            pauseMenue.SetActive(true);
            player.GetComponent<FirstPersonController>().enabled = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
    }

    public void backToMainMenue()
    {

        Application.LoadLevel("Start");
    }

    public void cancel()
    {

        pauseMenue.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }



}
