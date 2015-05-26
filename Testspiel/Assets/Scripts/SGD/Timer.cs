using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private GameObject calibrationScreen;
    private GameObject player;
    private int counter = 5;
    public Text counterText;



    void Start()
    {
        Debug.Log("Start Timer Script");
        calibrationScreen = GameObject.FindGameObjectWithTag("Calibration");
        player = GameObject.FindGameObjectWithTag("Player");

        counterText.text = "" + counter;
        StartCoroutine(countdown());
 

    }


    IEnumerator countdown()
    {
        while (counter > 0)
        {
            counterText.text = counter.ToString();
            yield return new WaitForSeconds(1);

            

            counter -= 1;
            counterText.text = counter.ToString();
            //Debug.Log(counter);
        }

        
        calibrationScreen.SetActive(false);
        player.GetComponent<EyeTrackerData>().isChosen = true;
    }
}

