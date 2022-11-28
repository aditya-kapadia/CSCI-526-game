using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ChangeSound : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button volumeButton;
    private bool isOn = true;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        soundOnImage = volumeButton.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClicked()
    {
        if (isOn)
        {
            volumeButton.image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
        }
        else
        {
            volumeButton.image.sprite = soundOnImage;
            isOn = true;
            audioSource.mute = false;
        }
    }
}
