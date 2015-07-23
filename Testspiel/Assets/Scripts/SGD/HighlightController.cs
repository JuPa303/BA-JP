using UnityEngine;
using System.Collections;

public class HighlightController : MonoBehaviour
{
    /*
     * This determines when the clue is visible and when it's not. 
     */
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


    // If the arrow is not killed yet, it is just made invisible. If it is killed, 
    void Update()
    {

        if (arrowIsKilled == false)
        {
            getDataFromScripts();
            arrow.SetActive(true);

            cluePos = Camera.main.WorldToScreenPoint(clue.transform.position);
            viewportPos = Camera.main.WorldToViewportPoint(clue.transform.position);

            if (showClue)
            {
                makeArrowVisible();
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

    //get the closest clue from FindClosestClue
    private void getDataFromScripts()
    {
        clue = player.GetComponent<FindClosestClue>().closest;
        arrow = clue.transform.GetChild(0).gameObject;
    }


    //sets the density of the arrow to 0
    private void makeArrowInvisible()
    {
        arrow.GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 0);
    }

    //sets the density of the arrow to 50
    private void makeArrowVisible()
    {
        arrow.GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 50);
    }

}
