using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class starsHandler : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject nextButton;
    public ItemCollector collectorObj;
    public Text text;
    public Image min_coins;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }



    public void starsAchieved(double avgCoinsCollected)
    {

        avgCoinsCollected = avgCoinsCollected * 100;
        min_coins.enabled = false;
        if (avgCoinsCollected < 33)
        {
            Debug.Log("I have zero stars");
            //text.text = "Not Enough Coins";
            min_coins.enabled = true;
           //# stars[0].SetActive(true);
        }
        else if (avgCoinsCollected >= 33 && avgCoinsCollected < 66)
        {
            stars[0].SetActive(true);
            nextButton.SetActive(true);
            //min_coins.enabled = false;
        }

        else if (avgCoinsCollected >= 66 && avgCoinsCollected < 70)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            nextButton.SetActive(true);
            //min_coins.enabled = false;

        }

        else 
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            //min_coins.enabled = false;
            nextButton.SetActive(true);
        }

    }
}
