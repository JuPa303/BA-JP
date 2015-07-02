using UnityEngine;
using System.Collections;
using System.IO;

public class Filewriter : MonoBehaviour
{

    // Use this for initialization
    private string fileName;
    private string sceneName;
    public string time = "";
    public bool countingEnds = false;

    private int sceneCounter = 0;
    public float gazeTimeCounter = 0.0f;
    public int gazeCounter = 0;

    private StreamWriter sr;

    void Start()
    {
        sceneName = "" + Application.loadedLevelName;
        setFileName();
    }

    // Update is called once per frame
    void Update()
    {
        writeData();

    }

    private void setFileName()
    {
        fileName = sceneName + sceneCounter + ".txt";
        if (File.Exists(fileName))
        {
            sceneCounter++;
            setFileName();
        }
        else
        {
            sr = File.CreateText(fileName);

        }
    }

    private void writeData()
    {
        if (countingEnds == true)
        {
            sr.WriteLine("Level: " + sceneName);
            sr.WriteLine("Time needed in this Level: " + time + " seconds");
            sr.WriteLine("Gaze on navigation clues: " + gazeTimeCounter + " seconds");
            sr.WriteLine("Number of gazes on navigation clues: " + gazeCounter + " times");

            sr.Close();
            countingEnds = false;
        }
    }
}
