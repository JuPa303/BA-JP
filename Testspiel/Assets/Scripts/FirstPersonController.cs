using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour
{

    private float movementSpeed = 3.0f;
    public float mouseSensitivity = 3.0f;

    public float jumpSpeed = 6.0f;

    public float upDownRange = 60.0f;
    float rotUpDown = 0;
    float verticalVelocity = 0;

    CharacterController characterController;

    // Use this for initialization
    void Start()
    {
       // Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();

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

            verticalVelocity = jumpSpeed;
        }

        //Sprint
        if (characterController.isGrounded && Input.GetButton("Sprint"))
        {

            movementSpeed = 8.0f;
        }
        else
            movementSpeed = 4.0f;

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime);

    }
}
