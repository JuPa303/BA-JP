using UnityEngine;
using System.Collections;
using iView;

public class EyeTrackerData : GazeMonobehaviour
{
    public bool isMouseModusActive = false;

    //public bool showClue = false;
    Vector3 averageGazePosition, vectorToClue2D, vectorToGaze;
    Vector2 gazePos, gazePoint1, gazePoint2;

    private GameObject objectInFocus;
    private GameObject clue;
    private GameObject player;
    private GameObject data;
    SampleData sample;

    private float angle = 0f;

    public bool hasToWait = false;
    public bool isChosen = false;
    private bool hasFirstPoint = false;
    public bool quitCounting = false;

    private bool stopShowing;

    public delegate void cueHandler(bool isShown);
    public event cueHandler OnClueStatus = delegate { };

    public HighlightController highContr;
   
   

    //int calibrationType = 5;
    //private bool didCalibration = false;

    // public GameObject timer;


    public float gazeTimeCounter = 0.0f;
    public float killTimer = 0.0f;





    // Use this for initialization
    void Start()
    {

        OnClueStatus(false);
        data = GameObject.FindGameObjectWithTag("Data");
        highContr = Camera.main.GetComponent<HighlightController>();

    }


    // Update is called once per frame
    void Update()
    {
        //if (isChosen == true)
        //{

        //calibrateET();

        clue = GetComponent<FindClosestClue>().FindClue();
        sample = SMIGazeController.Instance.GetSample();
        gazePos = sample.averagedEye.gazePosInScreenCoords();
        checkGazeTime();
        checkGazeOnObject();
        getGazes();
        //Debug.Log("isKilled" + highContr.arrowIsKilled);
        //}

    }


    private void getGazes()
    {

        //Debugmode is Active


        if (hasFirstPoint == false || gazePoint1 == Vector2.zero)
        {

            gazePoint1 = sample.averagedEye.gazePosInScreenCoords();
            hasFirstPoint = true;

        }
        else
        {
            gazePoint2 = sample.averagedEye.gazePosInScreenCoords();
            calcDirection();
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
                //clue = objectInFocus;
                OnClueStatus(false);

                if ((objectInFocus.tag == "Arrow") && (quitCounting == false))
                {
                    gazeTimeCounter += Time.deltaTime * 1;
                    killTimer += Time.deltaTime * 1;

                }
                if (quitCounting == true)
                {
                    data.GetComponent<Filewriter>().gazeTimeCounter = gazeTimeCounter;
                }

                //Debug.Log("gaze on clue");

            }

            else
            {
                killTimer = 0;
            }
        }

        catch (System.Exception e)
        {
            Debug.Log(e);
        }


    }


    private void checkGazeTime()
    {
        if (killTimer >= 0.25f)
        {
            highContr.arrowIsKilled = true;
            //OnClueStatus(false);
        }

    }


    //draw gaze as rectangle
    private void OnGUI()
    {
        //Texture2D square = new Texture2D(10, 10);
        //square.SetPixel(1, 1, Color.white);
        //square.Apply();
        //GUI.DrawTexture(new Rect(gazePos.x, gazePos.y, square.width, square.height), square);

    }


}

