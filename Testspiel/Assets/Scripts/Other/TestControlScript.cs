using UnityEngine;
using System.Collections;

public class TestControlScript : MonoBehaviour
{

    /*
     * COntrols only the button in the testing scene which leads back to the main menu
     */

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void backToMenu()
    {

        Application.LoadLevel("Start");

    }
}
