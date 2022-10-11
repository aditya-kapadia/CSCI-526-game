using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Settings_menu;
    
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

}
