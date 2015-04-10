using UnityEngine;
using System.Collections;

public class NewHighlight : MonoBehaviour
{

    public Texture aTexture;
    private Vector3 screenPos, viewportPos;
    private bool isSeen;
    private GameObject ball;


    // Use this for initialization
    void Start()
    {
        
        ball = GameObject.FindGameObjectWithTag("Ball");
        
    }

    // Update is called once per frame
    void Update()
    {

        screenPos = Camera.main.WorldToScreenPoint(ball.transform.position);
        // Debug.Log("screenPos" + screenPos);

        viewportPos = Camera.main.WorldToViewportPoint(ball.transform.position);
        
        if ((0 < viewportPos.x && viewportPos.x < 1) && (0 < viewportPos.y && viewportPos.y < 1)&& (viewportPos.z >0))
        {
            isSeen = true;
            //Debug.Log("is seen");
        }
        else
        {
            isSeen = false;
        }
        Debug.Log(isSeen);

    }
    // If both the x and y coordinate of the returned point is between 0 and 1 (and the z coordinate is positive), then the point is seen by the camera.



    void OnGUI()
    {
        GUI.color = new Color32(255, 255, 255, 100);
        if (isSeen)
        {
            GUI.DrawTexture(new Rect(screenPos.x, Screen.height - screenPos.y, 40, 40), aTexture, ScaleMode.StretchToFill);
        }
    }
}
