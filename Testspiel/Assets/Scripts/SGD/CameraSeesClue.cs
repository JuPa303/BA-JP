﻿using UnityEngine;
using System.Collections;

public class CameraSeesClue : MonoBehaviour
{
    private Vector3 direction;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = Camera.main.transform.position - transform.position;

    }

    public bool isBlocked(GameObject go)
    {

        RaycastHit hit;


        //Debug.DrawRay(transform.position, direction, Color.green);

        // Calculate Ray direction
        //direction = Camera.main.transform.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out hit))
        {


            if (hit.collider.tag == "Player") //hit something else before the camera
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