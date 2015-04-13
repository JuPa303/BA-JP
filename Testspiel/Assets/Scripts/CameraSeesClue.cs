using UnityEngine;
using System.Collections;

public class CameraSeesClue : MonoBehaviour
{

    //public bool isBlocked;
    private Vector3 direction;
   
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.transform.position - transform.position;


        //RaycastHit hit;
        //// Calculate Ray direction
        //Vector3 direction = Camera.main.transform.position - transform.position;
        //if (Physics.Raycast(transform.position, direction, out hit)){

           

        //    if (hit.collider.tag != "Player") //hit something else before the camera
        //    {
        //        isBlocked = true;
        //        Debug.Log("doesn't see Camera");
        //        Debug.Log("hit" +hit);


        //    }
        //    else
        //    {
        //        isBlocked = false;
        //        Debug.DrawRay(transform.position, direction, Color.green);
        //        Debug.Log("sees Camera");

        //   }
        //}
    }

   public bool isBlocked(GameObject go)
    {

        RaycastHit hit;
        // Calculate Ray direction
         //direction = Camera.main.transform.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out hit))
        {



            if (hit.collider.tag != "Player") //hit something else before the camera
            {
                
                Debug.Log("doesn't see Camera");
                Debug.Log("hit" + hit);
                return true;

            }
            else
            {
                
                Debug.DrawRay(transform.position, direction, Color.green);
                Debug.Log("sees Camera");
                return false;

            }
        }

        return false;

    }

    
}
