using UnityEngine;
using System.Collections;
using iView;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class EyetrackerGazeCounter : GazeMonobehaviour
{
    /*
     * This class counts how often the gaze hits the map.
     */
    SampleData sample;
    Vector2 gazePos;
    private bool increasing = false;
    public int counter;
    private Rect rect;

    private GameObject area;

    private GazeArea oldSelection;

    // Map area is a defined area around the map. Since the map is just a projection of a second camera, there has to be another object which lies on top of it, so the object will be detected.
    void Start()
    {
        area = GameObject.FindGameObjectWithTag("MapArea");
    }

    // Update is called once per frame
    void Update()
    {

        checkGazeOnMap();
    }

    // With the help of raycasting the gaze on the specified area can be detected .
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
        else
        {
            area.GetComponentInChildren<GazeArea>().isFocused = false;
        }

    }

}
