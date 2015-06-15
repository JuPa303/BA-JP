using UnityEngine;
using System.Collections;

public class MinimapEnd : MonoBehaviour
{
    private int system = 3;
    private GameObject end;
    private GameObject player;
    private GameObject skeleton;
    private GameObject data;
    private Animation danceAnim;


    // Use this for initialization
    void Start()
    {
        end = GameObject.FindGameObjectWithTag("End");
        player = GameObject.FindGameObjectWithTag("Player");
        skeleton = GameObject.FindGameObjectWithTag("Skeleton");
        danceAnim = skeleton.GetComponent<Animation>();

        data = GameObject.FindGameObjectWithTag("Data");
      
        
        end.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //get the number from toggle buttons
    public void setSystem(int sysNumber)
    {

        system = sysNumber;


    }

    //If player walks into collider, the endScreen will be shown, cursor will be unlocked and shown, dancing skeleton will appear.
    private void OnTriggerEnter(Collider collider)
    {
        player.GetComponent<FirstPersonController>().enabled = false;
        end.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        danceAnim.Play();

        data.GetComponent<TimeKeeper>().TimerIsRunning = false;




    }

    //player can choose between compass, sgd and quitting
    public void pressOkay()
    {
        if (system != 3)
        {
            if (system == 0)
            {
                Application.LoadLevel("Compass");
            }

            if (system == 1)
            {
                Application.LoadLevel("SGD");
            }

            if (system == 2)
            {
                Application.Quit();
            }
        }

    }
}