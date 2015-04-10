using UnityEngine;
using System.Collections;

public class SeesCamera : MonoBehaviour
{

    public bool isBlocked;
    private Renderer myRenderer;
    // Use this for initialization
    void Start()
    {
        myRenderer = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit hit;
        // Calculate Ray direction
        Vector3 direction = Camera.main.transform.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out hit)){
      
           // Debug.DrawRay(transform.position, direction, Color.green);

            if (hit.collider.tag != "Player") //hit something else before the camera
            {
                isBlocked = true;
                //Debug.Log("doesn't see Camera");

            }
            else
            {
                isBlocked = false;
                //Debug.Log("sees Camera");

           }
        }
    }
}
