using UnityEngine;
using System.Collections;
using iView;

public class EyeTrTest : GazeMonobehaviour
{
    Renderer rend;
    public bool gazeOnClue = false;
    Vector3 averageGazePosition, gazePoint1, gazePoint2, vectorToClue, vectorToGaze;
    Vector2 gazePos;
    GameObject objectInFocus, clue;
    SampleData sample;
    private float angle = 0f;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        sample = SMIGazeController.Instance.GetSample();
        averageGazePosition = sample.averagedEye.gazePosInUnityScreenCoords();
        gazePos = sample.averagedEye.gazePosInScreenCoords();
        //Debug.Log("averageGazePos" + averageGazePosition);
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


    private void calcDirection()
    {
        Vector3[] vectors;
        vectors = new Vector3[2];

        gazePoint1 = sample.averagedEye.eyePosition;

        vectors[0] = gazePoint1;
        vectors[1] = gazePoint2;
       


        vectorToClue = clue.transform.position - gazePoint1;
        //gazePoint2 = sample.averagedEye.eyePosition;
        vectorToGaze = gazePoint2 - gazePoint1;
        angle = Vector3.Angle(vectorToClue, vectorToGaze);

        if (angle <= 10)
        {
            //don't show clue image
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
       



    }


    //public override void OnGazeStay(RaycastHit hit)
    //{
    //    if (hit.collider.gameObject.tag == "Clue")
    //    {
    //       // Debug.Log("Kugel");
    //        rend.material.SetColor("_Color", Color.red);
    //        //base.OnGazeEnter(hit);
    //    }
    //    else
    //        rend.material.SetColor("_Color", Color.blue);
    //   // Debug.Log("nix");
    //}

    //public override void OnGazeExit()
    //{
    //    rend.material.SetColor("_Color", Color.blue);
    //}


    private void OnGUI()
    {


        Texture2D square = new Texture2D(20, 20);
        square.SetPixel(1, 1, Color.white);
        square.Apply();
        GUI.DrawTexture(new Rect(gazePos.x, gazePos.y, square.width, square.height), square);

    }

}
