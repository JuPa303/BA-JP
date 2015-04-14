using UnityEngine;
using System.Collections;
using iView;

public class EyeTrTest : GazeMonobehaviour
{
    Renderer rend;

    Vector3 averageGazePosition;
    Vector2 gazePos;
    GameObject objectInFocus;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        SampleData sample = SMIGazeController.Instance.GetSample();
        averageGazePosition = sample.averagedEye.gazePosInUnityScreenCoords();
        gazePos = sample.averagedEye.gazePosInScreenCoords();
        //Debug.Log("averageGazePos" + averageGazePosition);
         objectInFocus = SMIGazeController.Instance.GetObjectInFocus(FocusFilter.WorldSpaceObjects);
         if (objectInFocus.tag == "Clue")
         {
             rend.material.SetColor("_Color", Color.red);
         }
         else
             rend.material.SetColor("_Color", Color.blue);

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
