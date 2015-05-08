using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour
{

    private GameObject target;
    // Use this for initialization
    public Texture2D arrowUp;
    public Texture2D arrowLeft;
    public Texture2D arrowRight;
    public Texture2D arrowDown;
    // public Vector2 pivot;    // Where to place the center of the texture

    private Rect rect;


    //tex width = 128
    private float thresholdOutside = 10.0f;
    private float thresholdInside = 50.0f;

    private Vector3 arrowPos;

    private float currentNumber;
    //private float maximum;
    private bool hasPos = false;
    private float texHeight; //tex is square




    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        //pivot = new Vector2(Screen.width / 2, Screen.height / 2);
        texHeight = arrowUp.height;
        rect = new Rect(Screen.width * 0.5f, Screen.height * 0.5f, texHeight * 0.3f, texHeight * 0.3f);

    }

    void OnGUI()
    {
        getArrowPos();
    }



    private void getArrowPos()
    {
        Vector3 targetPos = Camera.main.WorldToScreenPoint(target.transform.position);
        arrowPos = targetPos;
        arrowPos.y = Screen.height - arrowPos.y;
        //Debug.Log("arrow" + arrowPos);

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
                arrowPos.y = Screen.height - thresholdOutside;
            }


            //left outside
            if (arrowPos.x < 0)
            {
                arrowPos.x = thresholdOutside;
            }


            //right outside
            if (arrowPos.x + texHeight > Screen.width)
            {
                arrowPos.x = Screen.width - thresholdOutside - texHeight;
            }


            //up inside
            if (arrowPos.y > thresholdInside && arrowPos.x < Screen.width - thresholdInside)
            {
                Debug.Log("Mitte");

                //right inside
                if ((arrowPos.x + texHeight) >= (Screen.width - thresholdInside))
                {
                    // Debug.Log("rechte Ecke");
                    drawArrow(arrowRight);

                }

                //left inside
                else if (arrowPos.x <= thresholdInside)
                {
                    // Debug.Log("linke ecke" + arrowPos.x);
                    drawArrow(arrowLeft);
                }

                else
                {

                    arrowPos.y = thresholdInside;
                    drawArrow(arrowUp);
                }


            }


            //rect.x = arrowPos.x;
            //rect.y = arrowPos.y;

            //GUI.DrawTexture(rect, arrowUp);
            //drawArrow(arrowUp);



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
                Debug.Log("Mitte unten");


                if (arrowPos.z < currentNumber)
                {
                    currentNumber = arrowPos.z;
                    hasPos = true;
                    //Debug.Log("werte werden kleiner");
                    arrowPos.x = arrowPos.x - 10;
                    arrowPos.y = Screen.height - texHeight;
                    drawArrow(arrowDown);

                }
                else
                {
                    //currentNumber = arrowPos.z;
                    //Werte werden größer
                    // Debug.Log("werte werden größer");
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
                Debug.Log("draw right arrow");
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
}

