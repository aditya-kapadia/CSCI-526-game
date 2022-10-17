using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelComplete : MonoBehaviour
{
    public sendtogform sg;
    public void Setup(double avgCoinsCollected)
    {
        sg.Send();
        MovePlatform.platformsUsed = 0;
        DeathScript.attempts = 0;
        ItemCollector.gfromcollectable = 0;
        ItemCollector.collectables = 0;
        sendtogform.level += 1;
        // Debug.Log(avgCoinsCollected);
        GetComponent<starsHandler>().starsAchieved(avgCoinsCollected);
        gameObject.SetActive(true);
    }

    public void NextLevel()
    {
        sendtogform.startSessionID = DateTime.Now;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
        Time.timeScale = 1f;
    }

}
