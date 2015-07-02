using UnityEngine;
using System.Collections;

public class FindClosestClue : MonoBehaviour
{
    public GameObject closest;
    private GameObject[] clues;
    private NavMeshAgent nav;


    private void Start()
    {

        nav = GetComponent<NavMeshAgent>();
        clues = GameObject.FindGameObjectsWithTag("AOI");
        closest = FindClue();
    }


    //returns the closest clue by calculating the distances
    public GameObject FindClue()
    {


        float distance = Mathf.Infinity;

        foreach (GameObject go in clues)
        {

            float curDistance = CalculatePathMesh(go.transform.position);
            go.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }

        }

        closest.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
        return closest;
    }


    void Update()
    {

        closest = FindClue();
    }



    //returns the path length to decide, which target is the closest
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

        return pathLength;

    }
}