using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour
{
   

    // Use this for initialization
    void Start()
    {
        turnToRed();
    }

    // Update is called once per frame
    void Update()
    {

    }

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
