using UnityEngine;
using System.Collections;

public class FindClosestClue : MonoBehaviour
{

    public GameObject closest;
    private NavMeshAgent nav;

    private void Start()
    {

        nav = GetComponent<NavMeshAgent>();

        closest = FindClue();
    }

    GameObject FindClue()
    {
        GameObject[] clues;
        clues = GameObject.FindGameObjectsWithTag("Clue");

        float distance = Mathf.Infinity;
       
        foreach (GameObject go in clues)
        {

            // Debug.Log(go.transform.position);
            float curDistance = CalculatePathMesh(go.transform.position);
            // Vector3 diff = go.transform.position - position;
            //float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


    void Update()
    {
        //FindClue();
        closest = FindClue();
        //print(FindClue().name);
    }

   public float CalculatePathMesh(Vector3 targetPosition)
    {
        NavMeshPath path = new NavMeshPath();

        if (nav.enabled)
        {
            nav.CalculatePath(targetPosition, path);

        }
        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        for (int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];

        }

        float pathLength = 0f;

        for (int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
        }
        //Debug.Log("pathlength" + pathLength);

        return pathLength;

    }
}