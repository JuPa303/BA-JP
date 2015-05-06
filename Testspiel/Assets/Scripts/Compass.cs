using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour
{

    private GameObject target;
    // Use this for initialization
    public Texture2D tex;    // Texture to be rotated
    public Vector2 pivot;    // Where to place the center of the texture

    private Rect rect;
    private float threshold = 20;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        //pivot = new Vector2(Screen.width / 2, Screen.height / 2);
        rect = new Rect(Screen.width / 2, Screen.height / 2, tex.width/2, tex.height/2);
        // rect = new Rect(pivot.x - tex.width * 0.5f, pivot.y - tex.height * 0.5f, tex.width, tex.height);
       // rect = new Rect(pivot.x - 100, pivot.y - 100, tex.width, tex.height);
    }

    void OnGUI()
    {

        Vector2 targetPos = Camera.main.WorldToScreenPoint(target.transform.position);
        Vector2 arrowPos = targetPos;
        Debug.Log("arrowPos.x" + arrowPos);


       

      
    

        if (arrowPos.y < 0)
        {
            arrowPos.y = threshold;
        }

        if (arrowPos.y+ tex.height > Screen.height)
        {
            arrowPos.y = Screen.height - threshold - tex.height;
        }

        if (arrowPos.x < 0)
        {
            arrowPos.x = threshold;
        }

        if (arrowPos.x+ tex.width > Screen.width)
        {
            arrowPos.x = Screen.width - threshold - tex.width; //hat keinen Einfluss
        }

        //dir.y = Screen.height - dir.y;

        rect.x = arrowPos.x;
        rect.y = arrowPos.y;
        //Vector3 screenCenter = new Vector3 (Screen.width, Screen.height, 0 / 2);

        //Vector3 screenBounds = screenCenter * 0.9f;

        //Debug.Log("rect" + rect.position);
        //Debug.Log("screen" + rect.position);

        //dir = dir - pivot;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Debug.Log("angle" + angle);

        //var matrixBackup = GUI.matrix;
        //GUIUtility.RotateAroundPivot(angle, pivot);
        GUI.DrawTexture(rect, tex);
        //GUI.matrix = matrixBackup;

    }
}

