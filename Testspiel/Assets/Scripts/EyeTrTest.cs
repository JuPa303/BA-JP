using UnityEngine;
using System.Collections;
using iView;

public class EyeTrTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
     
        
	}
	
	// Update is called once per frame
	void Update () {

        SampleData sample = SMIGazeController.Instance.GetSample();
        Vector3 averageGazePosition = sample.averagedEye.gazePosInUnityScreenCoords();
        Debug.Log("averageGazePos" + averageGazePosition);
        
	}
}
