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

    }

    public void OnGazeEnter()
    {

        if (!isFocused)
        {
            mapGazeTimer += Time.deltaTime * 1;
            counter++;
            isFocused = true;

        }
    }
}
