using UnityEngine;
using System.Collections;

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

    private GameObject coinCounter;

    private bool isSelected = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coinCounter = GameObject.FindGameObjectWithTag("Coins");
        //Safe the DefaultScale of the Item
        startScale = transform.localScale;
        //Init the Scalefactors
        scaleDestination = startScale;
        coin = this.gameObject;
        //Debug.Log("minx "+ minX +"miny "+ minY +"maxX "+ maxX +"maxY "+ maxY );
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, scaleDestination, 0.1f);

        checkPosition();
        grabCoin();
    }

 



    IEnumerator DecreaseSize()
    {
        yield return new WaitForSeconds(0.25f);
        scaleDestination = startScale;

    }

    private void checkPosition()
    {
        setValues();
        //Debug.Log("minx " + minX + "miny " + minY + "maxX " + maxX + "maxY " + maxY);
        //Debug.Log(Screen.width*0.17);


        Vector3 targetPos = Camera.main.WorldToScreenPoint(coin.transform.position);
        Vector3 playerPos = Camera.main.WorldToScreenPoint(player.transform.position);
        //Debug.Log("height" + Screen.height);
        //Debug.Log("width" + Screen.width);
        //Debug.Log(targetPos);
        float distance = Vector2.Distance(player.transform.position, coin.transform.position);
        //Debug.Log("Distance" + distance);

        if ((targetPos.x >= minX) && (targetPos.x <= maxX))
        {
            if ((targetPos.y >= minY) && (targetPos.y <= maxY))
            {
                if (distance >= 0.5 && distance <= 1.2)
                {
                    //Debug.Log("true");
                    scaleDestination = Vector3.one * highlightScaleFactor;
                    isSelected = true;
                }
            }
            else
            {
                scaleDestination = startScale;
                isSelected = false;

            }
        }
        else
        {
            scaleDestination = startScale;
            isSelected = false;
        }
    }


    private void setValues()
    {

        minX = (Screen.width / 2) - (Screen.width * 0.17);
        maxX = (Screen.width / 2) + (Screen.width * 0.17);

        minY = (Screen.height / 2) - (Screen.height * 0.17);
        maxY = (Screen.height / 2) + (Screen.height * 0.17);
    }


    private void grabCoin()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isSelected == true)
            {
                Debug.Log("Grab!");
                coinCounter.GetComponent<CoinCounter>().counter++;
                coin.SetActive(false);
            }
        }
    }
}