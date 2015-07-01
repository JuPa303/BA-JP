using UnityEngine;
using System.Collections;
using iView; 

public class GazeArea : GazeMonobehaviour
{

    public float mapGazeTimer = 0.0f;
    public bool isFocused = false; 

    public int counter = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("counter" + counter);
       

     
    }

    public void OnGazeEnter()
    {

        if (!isFocused)
        {
            mapGazeTimer += Time.deltaTime * 1;
            //Debug.Log("timer " + mapGazeTimer);
            counter++;
            isFocused = true;
            Debug.Log("counter" + counter);
        }


    }



    //public void OnGazeExit()
    //{

    //    isFocused = false;

    //}


    //public override void OnGazeEnter(RaycastHit hitInformation) //RaycastHit hitInformation
    //{
    //    Debug.Log("HIT");
    //    base.OnGazeEnter(hitInformation);
    //}

    //public override void OnGazeExit()
    //{


    //    base.OnGazeExit();

    //}



  
}
