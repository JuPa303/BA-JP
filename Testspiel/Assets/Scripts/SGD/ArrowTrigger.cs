using UnityEngine;
using System.Collections;

public class ArrowTrigger : MonoBehaviour
{
    HighlightController highContr;
    // Use this for initialization
    void Start()
    {
        highContr = Camera.main.GetComponent<HighlightController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player")
        {
            highContr.arrowIsKilled = false;

        }
    }
}
