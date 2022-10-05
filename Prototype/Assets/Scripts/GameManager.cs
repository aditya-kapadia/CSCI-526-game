using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    


    public void startGame()
    {
        SceneManager.LoadScene("Level1");
    }


}
