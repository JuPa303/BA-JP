using UnityEngine;
using System.Collections;

public class MapCamera : MonoBehaviour
{
    /*
     * This Script allows the second camera, which is displaying the map, to follow the player. Also the size is fixed.
     */
    public bool showMap;
    private GameObject player;
    private Camera mapCamera;

    public Texture2D playerTex;

    //the cursor is not movable and invisible
    void Start()
    {
        mapCamera = gameObject.GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Map stays the same size even on different screens, it's square
    void Update()
    {

        mapCamera.enabled = true;
        mapCamera.pixelRect = new Rect(Screen.width - 300, 50, 270, 270);


    }

    //this handles the position of the camera
    void OnGUI()
    {
        Vector3 targetPos = mapCamera.WorldToScreenPoint(player.transform.position);


    }

}
