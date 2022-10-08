using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    


    public void startGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GotoLvlSelector() {

        SceneManager.LoadScene("LevelSelectionMenu");
    }

    public void GotoLvlTwo()
    {

        SceneManager.LoadScene("Level2");
    }
    public void GotoLvlThree()
    {

        SceneManager.LoadScene("Level3");
    }
    public void GotoMainMenu()
    {

        SceneManager.LoadScene("Mainmenu");
    }
}
