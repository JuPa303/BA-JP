using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
    /*
     * This is written to change the color and density of the arrows at runtime
     */

    // Use this for initialization
    void Start()
    {
        turnToRed();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //the arrows turn red with a density of 50
    public void turnToRed()
    {
        GameObject[] clues;
        clues = GameObject.FindGameObjectsWithTag("AOI");


        foreach (GameObject go in clues)
        {

            go.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 50);

        }
    }
}
