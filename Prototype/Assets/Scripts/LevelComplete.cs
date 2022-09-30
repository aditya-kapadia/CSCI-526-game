using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public sendtogform sg;
    public void Setup()
    {
        sg.Send();
        MovePlatform.platformsUsed = 0;
        sendtogform.level = 2;
        gameObject.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    

}
