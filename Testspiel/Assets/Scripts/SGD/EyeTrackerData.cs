﻿using UnityEngine;
using System.Collections;
using iView;

public class EyeTrackerData : GazeMonobehaviour
{
    public bool isMouseModusActive = false;


    //public bool showClue = false;
    Vector3 averageGazePosition, vectorToClue2D, vectorToGaze;
    Vector2 gazePos, gazePoint1, gazePoint2;
    GameObject objectInFocus, clue, player;
    SampleData sample;
    private bool hasFirstPoint = false;
    private float angle = 0f;

    public bool hasToWait = false;

    public bool isChosen = false;

    public delegate void cueHandler(bool isShown);
    public event cueHandler OnClueStatus = delegate { };

    int calibrationType = 5;
    private bool didCalibration = false;

    public GameObject timer;




    // Use this for initialization
    void Start()
    {

        
        // isMouseModusActive = true;
        // Debug.Log("EyeTrackerData");
        OnClueStatus(false);
        //timer = GameObject.FindGameObjectWithTag("Timer");



    }


    // Update is called once per frame
    void Update()
    {
        if (isChosen == true)
        {

           // Debug.Log("start update Eyetracker data");


            //calibrateET();

            clue = GetComponent<FindClosestClue>().FindClue();
            sample = SMIGazeController.Instance.GetSample();
            gazePos = sample.averagedEye.gazePosInScreenCoords();

            //getGazes();
            //checkGazeOnObject();

            //if (hasToWait == true)
            //{
            //    OnClueStatus(false);
            //    Debug.Log("Start wait coroutine");
            //    StartCoroutine(waitToDisplayClues());

            //}
            //else
            //{
            //    //Debug.Log("no coroutine");
            getGazes();
            checkGazeOnObject();
            //}

        }

    }


    //not wait because players are too fast
    public IEnumerator waitToDisplayClues()
    {

        yield return new WaitForSeconds(3f); // waits 3 seconds
        hasToWait = false;

    }

    private void calibrateET()
    {
        if (didCalibration == false)
        {

            SMIGazeController.Instance.StartCalibration(calibrationType);
            didCalibration = true;

        }

    }

    private void getGazes()
    {

        //Debugmode is Active
        if (isMouseModusActive == false)
        {
            if (hasFirstPoint == false || gazePoint1 == Vector2.zero)
            {

                gazePoint1 = sample.averagedEye.gazePosInScreenCoords();
                hasFirstPoint = true;
                // Debug.Log("gazePoint2" + gazePoint2);


            }
            else
            {
                gazePoint2 = sample.averagedEye.gazePosInScreenCoords();
                // gazePoint2 = sample.averagedEye.eyePosition;
                //Debug.Log("gazePoint2 " + gazePoint2);
                calcDirection();
            }
        }

            //DebugMode
        else
        {
            if (hasFirstPoint == false || gazePoint1 == Vector2.zero)
            {

                gazePoint1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                hasFirstPoint = true;
                Debug.Log("mouse pos1" + gazePoint1);

            }
            else
            {

                gazePoint2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("mouse pos2" + gazePoint2);
                calcDirection();
            }
        }

    }



    private void calcDirection()
    {
        //get vectors and distances between gaze points and clue

        Vector3 cluePos3D = clue.transform.position;
        Vector2 cluePos2D = Camera.main.WorldToScreenPoint(cluePos3D);
        vectorToClue2D = cluePos2D - gazePoint1;
        vectorToGaze = gazePoint2 - gazePoint1;


        float distanceOfGazeVectors = Vector2.Distance(gazePoint1, gazePoint2);

        //float distanceGP1ToClue = Vector2.Distance(gazePoint1, cluePos2D);
        //float distanceGP2ToClue = Vector2.Distance(gazePoint2, cluePos2D);

        //Debug.Log("GP1" + gazePoint1);
        //Debug.Log("GP2" + gazePoint2);



        //gazes are too close to get any difference for calculating the direction, seems to be fixation, keep first point
        // number from begaze/experiment center
        if (distanceOfGazeVectors <= 30)
        {
            hasFirstPoint = true;
            //Debug.Log("Skip");

        }

        //check if angle between gaze vector and clue are small enough, means to be in right direction
        else
        {

            angle = Vector3.Angle(vectorToClue2D, vectorToGaze);


            // looking in correct direction -> don't show clue image
            if (angle <= 20)
            {
                OnClueStatus(false);
                //Debug.Log("in richtige Richtung");

            }


            //looking in wrong direction, show clue again
            else
            {

                OnClueStatus(true);
            }

            //resets gazepoints
            hasFirstPoint = false;

        }
    }



    //check if user's gaze is directly on trigger or arrow
    private void checkGazeOnObject()
    {

        try
        {
            objectInFocus = SMIGazeController.Instance.GetObjectInFocus(FocusFilter.WorldSpaceObjects);
            if (objectInFocus.tag == "AOI" || objectInFocus.tag == "Arrow")
            {
                clue = objectInFocus;
                OnClueStatus(false);
                //Debug.Log("gaze on clue");
                
            }
        }

        catch (System.Exception e)
        {
            Debug.Log(e);
        }


    }



    //draw gaze as rectangle
    private void OnGUI()
    {
        Texture2D square = new Texture2D(10, 10);
        square.SetPixel(1, 1, Color.white);
        square.Apply();
        GUI.DrawTexture(new Rect(gazePos.x, gazePos.y, square.width, square.height), square);

    }



    //Nur ein Versuch, funktioniert so nicht ganz
    //private void screenData()
    //{
    //    Vector2 clueVec = Camera.main.WorldToScreenPoint(clue.transform.position);
    //    Vector2 gazeInScreenCoord = Camera.main.WorldToScreenPoint(gazePoint2);

    //    //double screenWidthInCm = (Screen.width * 2.54 / 96.0);
    //    //double screenHeightInCm = (Screen.height * 2.54 / 96.0);

    //    //calculating 2,5 cm in px
    //    double radiusCirclePx = (2.5 * Screen.dpi / 2.54);
    //    float distanceOfGaze = Vector2.Distance(gazeInScreenCoord, clueVec);
    //    Debug.Log("Distance" + distanceOfGaze);
    //    Debug.Log("gaze screen" + gazeInScreenCoord);
    //    Debug.Log("clueVec" + clueVec);
    //    //Debug.Log("radius" + radiusCirclePx);

    //    if (radiusCirclePx <= distanceOfGaze)
    //    {
    //        OnClueStatus(false);
    //        //Debug.Log("don't show");
    //    }
    //    else
    //    {
    //        OnClueStatus(true);
    //        //Debug.Log("show");
    //    }
    //}
}
