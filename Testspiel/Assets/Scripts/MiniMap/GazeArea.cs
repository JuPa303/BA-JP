using UnityEngine;
using System.Collections;

public class GazeArea : MonoBehaviour
{

    public float mapGazeTimer = 0.0f;

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
        mapGazeTimer += Time.deltaTime * 1;
        Debug.Log("counter " + mapGazeTimer);

     
    }

  
}
