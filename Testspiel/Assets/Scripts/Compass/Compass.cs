using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using iView;

public class Compass : MonoBehaviour
{

    public GameObject target;

    public Texture2D arrowUp;
    public Texture2D arrowLeft;
    public Texture2D arrowRight;
    public Texture2D arrowDown;

    private Rect rect;
    private Rect gazeRect;

    private Vector3 arrowPos;

    private float currentNumber;
    private float texHeight; //tex is square
    public float compassGazeTimer = 0.0f;
    private float thresholdOutside = 30.0f;
    private float thresholdInside = 50.0f;


    public bool isChosen;
    private bool hasPos = false;
    private bool isFocused = false;

    public int gazeCounter = 0;



    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        target = GameObject.Find("RoomTrigger0");
        //arrowUp.height = 128

        texHeight = 30.0f;
        rect = new Rect(Screen.width * 0.5f, Screen.height * 0.5f, texHeight, texHeight);

    }

    void OnGUI()
    {

        getArrowPos();

    }

    void Update()
    {
        checkGazeOnArrow();
        Debug.Log("counter" + gazeCounter);
        Debug.Log("Gazetime" + compassGazeTimer);
    }



    private void getArrowPos()
    {
        Vector3 targetPos = Camera.main.WorldToScreenPoint(target.transform.position);
        arrowPos = targetPos;
        arrowPos.y = Screen.height - arrowPos.y;

        //if camera is facing towards the target
        if (targetPos.z > 0)
        {

            //up outside
            if (arrowPos.y < 0)
            {
                arrowPos.y = thresholdOutside;
            }


            //down outside
            if (arrowPos.y + arrowUp.height > Screen.height - thresholdOutside)
            {
                arrowPos.y = Screen.height - thresholdOutside - texHeight;
            }


            //left outside
            if (arrowPos.x < 0)
            {
                arrowPos.x = thresholdOutside;
            }


            //right outside
            if (arrowPos.x + texHeight > Screen.width)
            {
                arrowPos.x = Screen.width - thresholdOutside - texHeight;/// 2;
            }


            //up inside
            if (arrowPos.y > thresholdInside && arrowPos.x < Screen.width - thresholdInside)
            {


                //right inside
                if ((arrowPos.x + texHeight) >= (Screen.width - thresholdInside))
                {

                    drawArrow(arrowRight);

                }

                //left inside
                else if (arrowPos.x <= thresholdInside)
                {

                    drawArrow(arrowLeft);
                }

                else
                {

                    arrowPos.y = thresholdInside;
                    drawArrow(arrowUp);
                }


            }

        }
        //if camera is not facing towards the target
        else
        {
            checkArrowPosBehindPlayer();

        }

    }

    private void checkArrowPosBehindPlayer()
    {

        if (hasPos == false)
        {
            arrowPos.x = Screen.width / 2;
            arrowPos.y = Screen.height - texHeight;
            currentNumber = arrowPos.z;
            hasPos = true;

        }

        else
        {
            if ((arrowPos.x >= thresholdInside) && (arrowPos.y < Screen.height) && (arrowPos.x <= (Screen.width - thresholdInside - texHeight)))
            {

                //z.Pos gets smaller
                if (arrowPos.z < currentNumber)
                {
                    currentNumber = arrowPos.z;
                    hasPos = true;
                    arrowPos.x = arrowPos.x - 10;
                    drawArrow(arrowDown);

                }
                //z.Pos gets bigger
                else
                {
                    arrowPos.x = arrowPos.x + 10;
                    arrowPos.y = Screen.height - texHeight;
                    drawArrow(arrowDown);

                }
            }

            //left outside
            else if (arrowPos.x < 0)
            {
                arrowPos.x = thresholdOutside;
                drawArrow(arrowLeft);
            }



            //right outside
            else if (arrowPos.x + texHeight > Screen.width)
            {
                arrowPos.x = Screen.width - thresholdOutside - texHeight;
                drawArrow(arrowRight);
            }
        }

    }

    private void drawArrow(Texture2D arrow)
    {

        rect.x = arrowPos.x;
        rect.y = arrowPos.y;

        GUI.DrawTexture(rect, arrow);

    }



    private void checkGazeOnArrow()
    {

        gazeRect = new Rect(rect.x, rect.y, texHeight * 3, texHeight * 3);
        //Create A PointerEvent for a Screenspace Canvas
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = SMIGazeController.Instance.GetSample().averagedEye.gazePosInScreenCoords();

        //Safe the Raycast
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        if (gazeRect.Contains(pointer.position))
        {
            Debug.Log("Gaze");
            compassGazeTimer += Time.deltaTime * 1;
            if (!isFocused)
            {
                gazeCounter++;

                isFocused = true;
            }
        }
        else
        {
            isFocused = false;
        }

    }
}

