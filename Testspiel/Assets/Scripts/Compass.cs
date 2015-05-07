using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour
{

    private GameObject target;
    // Use this for initialization
    public Texture2D tex;    // Texture to be rotated
    public Vector2 pivot;    // Where to place the center of the texture

    private Rect rect;


    //tex width = 128
    private float thresholdOutside = 10.0f;
    private float thresholdInside = 50.0f;




    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        //pivot = new Vector2(Screen.width / 2, Screen.height / 2);
        rect = new Rect(Screen.width / 2, Screen.height / 2, tex.width / 2, tex.height / 2);

        // rect = new Rect(pivot.x - tex.width * 0.5f, pivot.y - tex.height * 0.5f, tex.width, tex.height);
        // rect = new Rect(pivot.x - 100, pivot.y - 100, tex.width, tex.height);

        Debug.Log("width" + Screen.width);
    }

    void OnGUI()
    {
        getArrowPos();


    }

    private void getArrowPos()
    {
        Vector3 targetPos = Camera.main.WorldToScreenPoint(target.transform.position);
        Vector3 arrowPos = targetPos;
        arrowPos.y = Screen.height - arrowPos.y;
        Debug.Log("arrow" + arrowPos);

        //if camera is facing towards the target
        if (targetPos.z > 0)
        {

            //up outside
            if (arrowPos.y < 0)
            {
                arrowPos.y = thresholdOutside;
            }


            //down outside
            if (arrowPos.y + tex.height > Screen.height - thresholdOutside)
            {
                arrowPos.y = Screen.height - thresholdOutside;
            }


            //left outside
            if (arrowPos.x < 0)
            {
                arrowPos.x = thresholdOutside;
            }



            //right outside
            if (arrowPos.x + tex.width > Screen.width)
            {
                arrowPos.x = Screen.width - thresholdOutside - tex.width;
            }


            //up inside
            if (arrowPos.y > thresholdInside && arrowPos.x < Screen.width - thresholdInside)
            {
                Debug.Log("Screen.width- thresholdInside" + (Screen.width - thresholdInside));
                Debug.Log("x" + arrowPos.x);
                //right inside
                if ((arrowPos.x + tex.width) >= (Screen.width - thresholdInside))
                {
                    Debug.Log("rechte Ecke");

                }

                //left inside
                else if (arrowPos.x <= thresholdInside)
                {
                    Debug.Log("linke ecke" + arrowPos.x);
                }

                else
                {

                    arrowPos.y = thresholdInside;
                }


            }


            rect.x = arrowPos.x;
            rect.y = arrowPos.y;

            GUI.DrawTexture(rect, tex);


        }
        //if camera is not facing towards the target
        else
        {

            arrowPos.x = Screen.width / 2;
            arrowPos.y = Screen.height - tex.height;


            rect.x = arrowPos.x;
            rect.y = arrowPos.y;

            GUI.DrawTexture(rect, tex);
        }

    }

}

