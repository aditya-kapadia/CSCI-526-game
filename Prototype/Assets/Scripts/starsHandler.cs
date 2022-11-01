using UnityEngine;
using System.Collections;

public class starsHandler : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject nextButton;
    public ItemCollector collectorObj;
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
        if (avgCoinsCollected < 66)
        {
            stars[0].SetActive(true);
        }

        else if (avgCoinsCollected >= 66 && avgCoinsCollected < 70)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            nextButton.SetActive(true);

        }

        else 
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            nextButton.SetActive(true);
        }

    }
}
