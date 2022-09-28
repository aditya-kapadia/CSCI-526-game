using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SwitchMode : MonoBehaviour, IPointerDownHandler
{

    private GameObject playerObj;
    private GameObject[] platformArray;

    public Button playButton;
    public Button resetButton;


    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindWithTag("Player");
        platformArray = GameObject.FindGameObjectsWithTag("Platform");

        if (playButton.gameObject.activeSelf)
            BuildMode();
        else
            PlayMode();


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bool InBuildMode = playButton.gameObject.activeSelf;
        playButton.gameObject.GetComponent<BlinkPulse>().enabled = false;
        playButton.gameObject.GetComponent<Image>().color = new Color(1,1,1);

        if (InBuildMode) // play mode selected
        {
            PlayMode();
            playButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(true);



        }
        else // reset selected
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void BuildMode()
    {
        
        foreach (var platform in platformArray)
        {
            playerObj.gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
        playerObj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

    }

    void PlayMode()
    {
        foreach (var platform in platformArray)
        {
            playerObj.GetComponent<Collider2D>().isTrigger = false;
        }
        playerObj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
