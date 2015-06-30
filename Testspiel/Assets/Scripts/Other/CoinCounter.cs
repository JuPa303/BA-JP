using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

    public int counter = 0;
    public Text counterText;
    // Use this for initialization
    void Start()
    {
        counterText.text = "" + counter;
    }

    // Update is called once per frame
    void Update()
    {
      
        counterText.text = "" + counter;
    }
}
