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
    public Image level_success;
    public Image level_failed;
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
        level_success.enabled = true;
        level_failed.enabled = false;
        if (avgCoinsCollected < 66)
        {
            // Debug.Log("I have zero stars");
            //text.text = "Not Enough Coins";
            level_success.enabled = false;
            level_failed.enabled = true;
            min_coins.enabled = true;
            //# stars[0].SetActive(true);
        }
        else if (avgCoinsCollected >= 66 && avgCoinsCollected <80)
        {
            stars[0].SetActive(true);
            nextButton.SetActive(true);
            //min_coins.enabled = false;
        }

        else if (avgCoinsCollected >=80 && avgCoinsCollected < 100)
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
