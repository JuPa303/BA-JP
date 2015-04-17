using UnityEngine;
using System.Collections;
using iView;

public class EyeTrTest : GazeMonobehaviour
{
    
    public bool gazeOnClue = false;
    Vector3 averageGazePosition, gazePoint2, vectorToClue, vectorToGaze;
    Vector3 gazePoint1;
    Vector2 gazePos ;
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
        
        Debug.Log("averageGazePos" + averageGazePosition);
        
        getGazes();
        //checkGazeOnObject();
       
    }



    private void getGazes()
    {

        if (hasFirstPoint == false)
        {
            
            gazePoint1 = sample.averagedEye.eyePosition;
            Debug.Log("gazePoint1 "+ gazePoint1);

        }
        else
        {
           
            gazePoint2 = sample.averagedEye.eyePosition;
            Debug.Log("gazePoint2 " + gazePoint2);
            calcDirection();
        }

    }



    private void calcDirection()
    {

        //Vektoren sollen 2D sein, da sonst die Berechnung nicht stimmt, ÄNDERN
        Vector3[] vectors;
        vectors = new Vector3[2];

        vectors[0] = gazePoint1;
        vectors[1] = gazePoint2;

        vectorToClue = clue.transform.position - gazePoint1;
        gazePoint2 = sample.averagedEye.eyePosition;
        vectorToGaze = gazePoint2 - gazePoint1;
        angle = Vector3.Angle(vectorToClue, vectorToGaze);

        if (angle <= 10)
        {
            //don't show clue image
           Debug.Log("in richtige Richtung");
        }

        hasFirstPoint = false;
        

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


//foreach (Vector3 v in vectors)
//{

//    float curDistance = CalculatePathMesh(go.transform.position);
//    if (curDistance < distance)
//    {
//        closest = go;
//        distance = curDistance;
//    }
//}
