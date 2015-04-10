using UnityEngine;
using System.Collections;

public class NewHighlight : MonoBehaviour
{

    public Texture aTexture;
    private Vector3 screenPos, viewportPos;
    private bool isSeen;
    private GameObject clue, player;
    
    bool isBlockedByWall;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //clue = GameObject.FindGameObjectWithTag("Clue");
        getDataFromScripts();
 

    }

    // Update is called once per frame
    void Update()
    {

        getDataFromScripts();
      

        screenPos = Camera.main.WorldToScreenPoint(clue.transform.position);
        // Debug.Log("screenPos" + screenPos);

        viewportPos = Camera.main.WorldToViewportPoint(clue.transform.position);
        // If both the x and y coordinate of the returned point is between 0 and 1 (and the z coordinate is positive), then the point is seen by the camera.
        //Picture only displayed when camera facing towards clue

        if ((0 < viewportPos.x && viewportPos.x < 1) && (0 < viewportPos.y && viewportPos.y < 1) && (viewportPos.z > 0)) 
        {
            //no wall between Player and clue 
            if (!isBlockedByWall) 
            {

                isSeen = true; 
            }
            else
            {
                isSeen = false;

            } 

        }
        else
        {
            isSeen = false;
        }
        //Debug.Log(isSeen);

    }
    

    void OnGUI()
    {
        GUI.color = new Color32(255, 255, 255, 100);
        if (isSeen)
        {
            GUI.DrawTexture(new Rect(screenPos.x, Screen.height - screenPos.y, 40, 40), aTexture, ScaleMode.StretchToFill);
        }

    }

    private void getDataFromScripts()
    {
        clue = player.GetComponent<FindClosestClue>().closest;
        isBlockedByWall = clue.GetComponent<SeesCamera>().isBlocked;

    }
}
