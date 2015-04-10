using UnityEngine;
using System.Collections;

public class FindClosestClue : MonoBehaviour
{

     public GameObject closest;

    private void Start()
    {
        closest = FindClue();
    }

    GameObject FindClue()
    {
        GameObject[] clues;
        clues = GameObject.FindGameObjectsWithTag("Clue");

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in clues)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
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
}