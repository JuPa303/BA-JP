﻿using UnityEngine;
using System.Collections;
using iView;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class EyetrackerGazeCounter : GazeMonobehaviour
{

    SampleData sample;
    Vector2 gazePos;
    private bool increasing = false;
    public int counter;
    private Rect rect;

    private GazeArea oldSelection;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        checkGazeOnMap();
    }

    private void checkGazeOnMap()
    {


        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = SMIGazeController.Instance.GetSample().averagedEye.gazePosInUnityScreenCoords();

        //Safe the Raycast
        var raycastResults = new List<RaycastResult>();



        EventSystem.current.RaycastAll(pointer, raycastResults);

        if (raycastResults.Count > 0)
        {


            GazeArea item = raycastResults[0].gameObject.GetComponent<GazeArea>();

            if (item)
            {

                item.OnGazeEnter();
            }
        }
    }


    private void increaseCounter()
    {

        if (increasing == true)
        {
            counter++;
            increasing = false;
            //Debug.Log("Counter " + counter);
        }
    }



}