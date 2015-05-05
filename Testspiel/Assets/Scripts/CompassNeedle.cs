using UnityEngine;
using System.Collections;

public class CompassNeedle : MonoBehaviour {
    private GameObject target;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Target");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPostition = new Vector3(this.transform.position.x, target.transform.position.y, this.transform.position.z);
        this.transform.LookAt(targetPostition);

        //transform.LookAt(target.transform, Vector3.zero);
	}
}
