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

    void OnGUI()
    {
        Vector3 targetPos = mapCamera.WorldToScreenPoint(player.transform.position);
        

    }

}
