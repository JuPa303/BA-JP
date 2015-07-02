using UnityEngine;
using System.Collections;

public class HighlightController : MonoBehaviour
{
    public Texture aTexture;
    private Vector3 cluePos;
    private Vector3 viewportPos;

    private bool isClosestAndSeen;
    private bool isBlockedByWall;
    private bool showClue;
    public bool arrowIsKilled;

    public EyeTrackerData eyeData;

    private GameObject arrow;
    private GameObject clue;
    private GameObject player;

    private float fadeTime = 0.3f;

    private Color solidColor, fadedColor;



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        eyeData = player.GetComponent<EyeTrackerData>();
        getDataFromScripts();
        eyeData.OnClueStatus += setClueStatus;
    }



    // Update is called once per frame
    void Update()
    {
        // Debug.Log("killed " + arrowIsKilled);
        if (arrowIsKilled == false)
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
                if (arrowIsKilled == true)
                {
                    arrow.SetActive(false);
                }
                else
                {
                    makeArrowVisible();

                }

            }
            else
            {
                makeArrowInvisible();
            }

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


    private void getDataFromScripts()
    {
        clue = player.GetComponent<FindClosestClue>().closest;
        arrow = clue.transform.GetChild(0).gameObject;
    }

    private void makeArrowInvisible()
    {
        arrow.GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 0);
    }


    private void makeArrowVisible()
    {
        arrow.GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 50);
    }

}
