using UnityEngine;
using System.Collections;

public class HighlightController : MonoBehaviour
{
    public Texture aTexture;
    private Vector3 cluePos, viewportPos;
    private GameObject clue, player;

    private bool isClosestAndSeen, isBlockedByWall, showClue;

    private int texUnit = 50; //height & width of texture

    public EyeTrackerData eyeData;

    private GameObject arrow;



    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        

        eyeData = player.GetComponent<EyeTrackerData>();
        getDataFromScripts();
        eyeData.OnClueStatus += setClueStatus;

        
        arrow.SetActive(false);

    }



    // Update is called once per frame
    void Update()
    {

        getDataFromScripts();

        cluePos = Camera.main.WorldToScreenPoint(clue.transform.position);
        viewportPos = Camera.main.WorldToViewportPoint(clue.transform.position);

        // If both the x and y coordinate of the returned point is between 0 and 1 (and the z coordinate is positive), then the point is seen by the camera.
        //Picture only displayed when camera facing towards clue
        //if ((0 < viewportPos.x && viewportPos.x < 1) && (0 < viewportPos.y && viewportPos.y < 1) && (viewportPos.z > 0))
        //{
        //no wall between Player and clue 
        if (showClue)
        {
            arrow.SetActive(true);
        }
        else
        {
            arrow.SetActive(false);
        }

    }

    private void setClueStatus(bool isShown)
    {
        showClue = isShown;

    }


    ////draws Icon on Clue only when clue is visible for player
    //void OnGUI()
    //{

    //    // GUI.color = new Color32(255, 255, 255, 20);
    //    if (isClosestAndSeen)
    //    {
    //        arrow.SetActive(true);

    //        //arrow.SetActive(false);

    //        //    GUI.DrawTexture(new Rect((cluePos.x - texUnit / 2), (Screen.height - cluePos.y - texUnit / 2), texUnit, texUnit), aTexture, ScaleMode.StretchToFill, true);
    //    }
    //    else
    //    {
    //        //arrow.SetActive(true);
    //        arrow.SetActive(false);

    //    }

    //}

    private void getDataFromScripts()
    {
        clue = player.GetComponent<FindClosestClue>().closest;
        arrow = clue.transform.GetChild(0).gameObject;
        //arrow.GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 80);

    }
}
