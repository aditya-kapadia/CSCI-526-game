using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public void startGame()
    {
        sendtogform.level = 1;
        sendtogform.startSessionID = DateTime.Now;
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void GotoLvlSelector() {

        SceneManager.LoadScene("LevelSelectionMenu");
    }

    public void GotoLvlTwo()
    {
        sendtogform.level = 2;
        sendtogform.startSessionID = DateTime.Now;
        SceneManager.LoadScene("Level2");
    }
    public void GotoLvlThree()
    {
        sendtogform.level = 3;
        sendtogform.startSessionID = DateTime.Now;
        SceneManager.LoadScene("Level3");
    }
    public void GotoLvlFour()
    {
        sendtogform.level = 4;
        sendtogform.startSessionID = DateTime.Now;
        SceneManager.LoadScene("Level4");
    }
    public void GotoMainMenu()
    {

        SceneManager.LoadScene("Mainmenu");
    }
}
