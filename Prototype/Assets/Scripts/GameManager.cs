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
        Time.timeScale = 1f;
    }
    public void GotoLvlFour()
    {
        sendtogform.level = 4;
        sendtogform.startSessionID = DateTime.Now;
        SceneManager.LoadScene("Level4");
        Time.timeScale = 1f;
    }
    public void GotoLvlFive()
    {
        sendtogform.level = 5;
        sendtogform.startSessionID = DateTime.Now;
        SceneManager.LoadScene("Level5");
        Time.timeScale = 1f;
    }
    public void GotoLvlSix()
    {
        sendtogform.level = 6;
        sendtogform.startSessionID = DateTime.Now;
        SceneManager.LoadScene("Level6");
        Time.timeScale = 1f;
    }
    public void GotoMainMenu()
    {

        SceneManager.LoadScene("Mainmenu");
    }
}
