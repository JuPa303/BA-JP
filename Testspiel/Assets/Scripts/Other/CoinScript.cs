using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CoinScript : MonoBehaviour
{

    private Vector3 scaleDestination;
    private Vector3 startScale;
    private float highlightScaleFactor = 1.5f;
    private GameObject coin;
    private GameObject player;
    private double minX;
    private double minY;
    private double maxX;
    private double maxY;


    public Text helpText;

    private GameObject coinCounter;

    private bool isSelected = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coinCounter = GameObject.FindGameObjectWithTag("Coins");
        startScale = transform.localScale;
        scaleDestination = startScale;
        coin = this.gameObject;
        helpText.enabled = false;

    }

    void Update()
    {

        transform.localScale = Vector3.Lerp(transform.localScale, scaleDestination, 0.1f);

        if (coinCounter.GetComponent<CoinCounter>().counter > 0)
        {
            helpText.text = "";
        }



    }



    private void OnTriggerEnter()
    {

        scaleDestination = Vector3.one * highlightScaleFactor;
        isSelected = true;
        helpText.enabled = true;
        

    }

    private void OnTriggerStay()
    {
        grabCoin();
    }

    private void OnTriggerExit()
    {
        scaleDestination = startScale;
        isSelected = false;
        helpText.enabled = false;

    }



    private void grabCoin()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("e pressed");
            if (isSelected == true)
            {
                coinCounter.GetComponent<CoinCounter>().counter++;
                coin.SetActive(false);
                scaleDestination = startScale;
                isSelected = false;
                helpText.enabled = false;
            }
        }
    }



}