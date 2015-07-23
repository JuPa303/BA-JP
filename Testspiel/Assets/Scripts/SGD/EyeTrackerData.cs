using UnityEngine;
using System.Collections;
using iView;

public class EyeTrackerData : GazeMonobehaviour
{
    public bool isMouseModusActive = false;

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
    private bool isFocused = false;
    private bool stopShowing;

    public delegate void cueHandler(bool isShown);
    public event cueHandler OnClueStatus = delegate { };

    public HighlightController highContr;


    public float gazeTimeCounter = 0.0f;
    public float killTimer = 0.0f;
    private float fixationTime = 0.15f;
    public int gazeCounter = 0;





    // Use this for initialization
    void Start()
    {

        OnClueStatus(false);
        data = GameObject.FindGameObjectWithTag("Data");
        highContr = Camera.main.GetComponent<HighlightController>();

    }


    // Time of gazes on the clues is updated, also if the gaze is on the clue
    void Update()
    {


        clue = GetComponent<FindClosestClue>().FindClue();
        sample = SMIGazeController.Instance.GetSample();
        gazePos = sample.averagedEye.gazePosInScreenCoords();
        checkGazeTime();
        checkGazeOnObject();
        getGazes();

    }

    //two gaze points are recorded, the have to have a specific distance for not being too close to each other
    private void getGazes()
    {

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
                if ((objectInFocus.tag == "Arrow") && (quitCounting == false))
                {
                    gazeTimeCounter += Time.deltaTime * 1;
                    killTimer += Time.deltaTime * 1;

                    if (!isFocused)
                    {
                        gazeCounter++;
                        isFocused = true;
                    }

                    OnClueStatus(false);

                }
                if (quitCounting == true)
                {
                    data.GetComponent<Filewriter>().gazeTimeCounter = gazeTimeCounter;
                }
                //Gaze on clue
            }

            else
            {
                killTimer = 0;
                isFocused = false;
            }
        }

        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }


    //if the gazing time is higher than the ficationTime, the arrow disapperars and won't be shown again as long if the player is not re-entering the room.
    private void checkGazeTime()
    {
        if (killTimer >= fixationTime)
        {
            highContr.arrowIsKilled = true;
        }

    }

}

