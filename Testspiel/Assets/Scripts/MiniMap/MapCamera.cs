using UnityEngine;
using System.Collections;

public class MapCamera : MonoBehaviour
{

    public bool showMap;
    private GameObject player;
    private Camera mapCamera;

    public Texture2D playerTex;


    void Start()
    {
        mapCamera = gameObject.GetComponent<Camera>();
       // showMap = false;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        //if (showMap == true)
        //{

            mapCamera.enabled = true;
            mapCamera.pixelRect = new Rect(Screen.width - 300, 50, 270,270);

        //}

        //else
        //{
        //    mapCamera.enabled = false;

        //}
    }

    void OnGUI()
    {
        Vector3 targetPos = mapCamera.WorldToScreenPoint(player.transform.position);
        //GUI.DrawTexture(new Rect(targetPos.x, targetPos.y, 20, 0), playerTex);

    }

    private void findTargets()
    {

        Vector3 targetPos = mapCamera.WorldToScreenPoint(player.transform.position);
    }
}
