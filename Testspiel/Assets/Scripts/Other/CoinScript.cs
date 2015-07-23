using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CoinScript : MonoBehaviour
{
    /*
     * This determines how coins are collectable and react if reached
     */
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


    // Initialize all important objects
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coinCounter = GameObject.FindGameObjectWithTag("Coins");
        startScale = transform.localScale;
        scaleDestination = startScale;
        coin = this.gameObject;
        helpText.enabled = false;

    }

    // scale of the object is calculated. The help text "Press E" is not displayed if more then one coins are collected
    void Update()
    {

        transform.localScale = Vector3.Lerp(transform.localScale, scaleDestination, 0.1f);

        if (coinCounter.GetComponent<CoinCounter>().counter > 0)
        {
            helpText.text = "";
        }

    }


    //If the player is close enough to the coin to reach it, he has entered a trigger. The coin will get bigger and if it's the first one, the help text will appear.
    private void OnTriggerEnter()
    {
        scaleDestination = Vector3.one * highlightScaleFactor;
        isSelected = true;
        helpText.enabled = true;

    }


    //The player is now able to grab the coin
    private void OnTriggerStay()
    {
        grabCoin();
    }

    //If the player leaves, the coin shrinks to its normal size, help text is no longer shown.
    private void OnTriggerExit()
    {
        scaleDestination = startScale;
        isSelected = false;
        helpText.enabled = false;
    }


    // If the user presses "E", the coin and the help text will dissappear and the counter will be increased.
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