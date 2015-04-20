using UnityEngine;
using System.Collections;
using iView;

public class EyeTrTest : GazeMonobehaviour
{
    public bool isMouseModusActive = false; 


    public bool gazeOnClue = false;
    Vector3 averageGazePosition, vectorToClue2D, vectorToGaze;
    Vector2 gazePos, gazePoint1, gazePoint2;
    GameObject objectInFocus, clue, player;
    SampleData sample;
    private bool hasFirstPoint = false;
    private float angle = 0f;

    // Use this for initialization
    void Start()
    {



        // player = GameObject.FindGameObjectWithTag("Player");
        //clue = player.GetComponent<FindClosestClue>().FindClue();

    }

    // Update is called once per frame
    void Update()
    {
        clue = GetComponent<FindClosestClue>().FindClue();
        //Debug.Log("get clue " + clue);
        sample = SMIGazeController.Instance.GetSample();
        averageGazePosition = sample.averagedEye.gazePosInUnityScreenCoords();
        gazePos = sample.averagedEye.gazePosInScreenCoords();

        //Debug.Log("averageGazePos" + averageGazePosition);

        getGazes();
        checkGazeOnObject();

    }



    private void getGazes()
    {
        //Debugmode is Active
        if (!isMouseModusActive)
        {
            if (hasFirstPoint == false || gazePoint1 == Vector2.zero)
            {

                gazePoint1 = sample.averagedEye.eyePosition;
                //Debug.Log("gazePoint1 "+ gazePoint1);
                //calcDirection();

                hasFirstPoint = true;

            }
            else
            {

                gazePoint2 = sample.averagedEye.eyePosition;
                //Debug.Log("gazePoint2 " + gazePoint2);
                calcDirection();
            }
        }

            //DebugMode
        else
        {
            if (hasFirstPoint == false || gazePoint1 == Vector2.zero)
            {

                gazePoint1 = Input.mousePosition;
                //Debug.Log("gazePoint1 "+ gazePoint1);
                //calcDirection();

                hasFirstPoint = true;

            }
            else
            {

                gazePoint2 = Input.mousePosition;
                //Debug.Log("gazePoint2 " + gazePoint2);
                calcDirection();
            }
        }


    }



    private void calcDirection()
    {

       
        Vector2[] vectors;
        vectors = new Vector2[2];

        vectors[0] = gazePoint1;
        vectors[1] = gazePoint2;


        Vector3 cluePos = clue.transform.position;
        vectorToClue2D = new Vector2(cluePos.x, cluePos.y) - gazePoint1;

        //Debug.Log("clue position " + cluePos);
        //Debug.Log("gazepoint 1 " + gazePoint1);
        //Debug.Log("vector to clue" + vectorToClue2D);

       // Debug.Log("gazepoint 2 " + gazePoint2);


        //gazePoint2 = sample.averagedEye.eyePosition;
        vectorToGaze = gazePoint2 - gazePoint1;
       // Debug.Log("vector to gaze " + vectorToGaze);


        float distanceOfGazeVectors = Vector3.Distance(gazePoint1, gazePoint2);

       // Debug.Log("Distance:" + distanceOfGazeVectors);

        if(distanceOfGazeVectors<=1)
        {
            hasFirstPoint = true;
            gazeOnClue = false;
           // Debug.Log("skip");
        }
        else
        {
           // Debug.Log("next");
            angle = Vector3.Angle(vectorToClue2D, vectorToGaze);

            if (angle <= 10)
            {
                //don't show clue image

                gazeOnClue = true;
                Debug.Log("in richtige Richtung");
            }

            hasFirstPoint = false;
           
        }
        ////Difference between first and second gaze point should be more than 1, so it should be between 1 and -1
        //if (((vectorToGaze.x <= 1.0f && -1.0f <= vectorToGaze.x))||(( vectorToGaze.y <= 1.0f && -1.0f <= vectorToGaze.y)))
        //{

        //    hasFirstPoint = true;
        //    Debug.Log("skip");
        //}

        //else
        //{
        //    Debug.Log("next");
        //    angle = Vector3.Angle(vectorToClue2D, vectorToGaze);

        //    if (angle <= 10)
        //    {
        //        //don't show clue image
        //        Debug.Log("in richtige Richtung");
        //    }

        //    hasFirstPoint = false;
        //}

    }



    private void checkGazeOnObject()
    {

        try
        {
            objectInFocus = SMIGazeController.Instance.GetObjectInFocus(FocusFilter.WorldSpaceObjects);
            if (objectInFocus.tag == "Clue")
            {
                clue = objectInFocus;
                gazeOnClue = true;
            }
            else
                gazeOnClue = false;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }

    }




    private void OnGUI()
    {


        Texture2D square = new Texture2D(20, 20);
        square.SetPixel(1, 1, Color.white);
        square.Apply();
        GUI.DrawTexture(new Rect(gazePos.x, gazePos.y, square.width, square.height), square);

    }

}

