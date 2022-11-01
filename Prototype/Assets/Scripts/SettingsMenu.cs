using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject Settings_menu;

    public DateTime startPause;
    public static TimeSpan pauseTime = TimeSpan.FromSeconds(0.0);
    // Start is called before the first frame update
    private void Start()
    {

    }

    public void settings_open() {
        startPause = DateTime.Now;
        // Debug.Log("Start:"+pauseTime.Seconds);
        Settings_menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GotoLvlSelector()
    {
        MovePlatform.platformsUsed = 0;
        DeathScript.attempts = 0;
        ItemCollector.gfromcollectable = 0;
        ItemCollector.collectables = 0;
        SceneManager.LoadScene("LevelSelectionMenu");
    }

    public void GotoMainMenu()
    {
        MovePlatform.platformsUsed = 0;
        DeathScript.attempts = 0;
        ItemCollector.gfromcollectable = 0;
        ItemCollector.collectables = 0;
        SceneManager.LoadScene("Mainmenu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseTime += DateTime.Now - startPause;
        // Debug.Log("PauseTime:"+pauseTime.Seconds);
        Settings_menu.SetActive(false);

    }

}
