using UnityEngine;
using System.Collections;

public class CameraSeesClue : MonoBehaviour
{
    /*
     * This is used to detect wether there is a wall between the camera and the clue or not. Was actually written for the clues as gui objects, but also usable for gameobjects
     */
    private Vector3 direction;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.transform.position - transform.position;

    }


    //if the view is blocked it returns false
    public bool isBlocked(GameObject go)
    {
        RaycastHit hit;

        // Calculate Ray direction
        if (Physics.Raycast(transform.position, direction, out hit))
        {

            if (hit.collider.tag == "Player")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}
