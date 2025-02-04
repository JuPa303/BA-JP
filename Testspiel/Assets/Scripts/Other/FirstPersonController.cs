﻿using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{

    /*
     * These are the controls for the player, how to move, jump and look around. 
     */

    private float movementSpeed = 3.5f;
    public float mouseSensitivity = 3.0f;

    public float jumpSpeed = 6.0f;

    public float upDownRange = 60.0f;
    float rotUpDown = 0;
    float verticalVelocity = 0;

    CharacterController characterController;

    NavMeshAgent navAgent;


    // Use this for initialization
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        navAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {


        //Rotation

        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        rotUpDown -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotUpDown = Mathf.Clamp(rotUpDown, -upDownRange, upDownRange);

        Camera.main.transform.localRotation = Quaternion.Euler(rotUpDown, 0, 0);

        //Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        //Jump
        if (characterController.isGrounded && Input.GetButtonDown("Jump"))
        {
            navAgent.enabled = false;
            verticalVelocity = jumpSpeed;

            StartCoroutine(wait());
        }

        //Sprint
        if (characterController.isGrounded && Input.GetButton("Sprint"))
        {

            movementSpeed = 7.0f;
        }
        else
        {
            movementSpeed = 3.5f;
        }

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime);


    }


    //wait until the player is back on the ground, otherwise  the navmeshagent and this script will conflict
    IEnumerator wait()
    {

        yield return new WaitForSeconds(1);
        navAgent.enabled = true;


    }
}
