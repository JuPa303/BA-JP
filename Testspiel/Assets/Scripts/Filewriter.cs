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

    private int counter = 0;

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
        fileName = sceneName + counter + ".txt";
        if (File.Exists(fileName))
        {
            counter++;
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

            sr.WriteLine("Time needed in this Level: " + time + "seconds");
            sr.Close();
            countingEnds = false;
        }
    }
}
