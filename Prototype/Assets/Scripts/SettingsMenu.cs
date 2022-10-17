using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject Settings_menu;

    // Start is called before the first frame update
    private void Start()
    {

    }

    public void settings_open() {
        Settings_menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GotoLvlSelector()
    {

        SceneManager.LoadScene("LevelSelectionMenu");
    }

    public void GotoMainMenu()
    {

        SceneManager.LoadScene("Mainmenu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Settings_menu.SetActive(false);

    }

}
