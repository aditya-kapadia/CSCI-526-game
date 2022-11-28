using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class starsHandler : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject nextButton;
    public ItemCollector collectorObj;
    public Text text;
    public Image min_coins;
    public Image level_success;
    public Image level_failed;

    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button volumeButton;
    private bool isOn = true;
    public AudioClip audioClip_S;
    public AudioClip audioClip_F;
    public AudioSource audioSource_Success;
    public AudioSource audioSource_Failure;
    public AudioSource audio_mainCamera;
    // Use this for initialization
    void Start()
    {
       
        //yield return new WaitForSeconds(audio.clip.length);
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

        //AudioListener.volume = 0;
        //soundOnImage = volumeButton.image.sprite;
        //AudioSource audio = GetComponent<AudioSource>();
        audio_mainCamera.volume = 0;
        audioSource_Success.clip = audioClip_S;
        audioSource_Success.Play();

        if (avgCoinsCollected < 66)
        {
            // Debug.Log("I have zero stars");
            //text.text = "Not Enough Coins";
            level_success.enabled = false;
            level_failed.enabled = true;

            min_coins.enabled = true;
            //# stars[0].SetActive(true);
            audioSource_Success.volume = 0;
            audioSource_Failure.clip = audioClip_F;
            audioSource_Failure.Play();
            //GetComponent<AudioSource>().Play();
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
    public void ButtonClicked()
    {
        if (isOn)
        {
            volumeButton.image.sprite = soundOffImage;
            isOn = false;
            //audioSource_Success.mute = true;
            //audioSource_Failure.mute = true;
        }
        else
        {
            volumeButton.image.sprite = soundOnImage;
            isOn = true;
            //audioSource_Success.mute = false;
        }
    }
}
