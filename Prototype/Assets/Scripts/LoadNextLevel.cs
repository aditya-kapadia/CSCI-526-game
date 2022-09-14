using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextLevel : MonoBehaviour
{

    public Button nextLevelButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = nextLevelButton.GetComponent<Button>();
        btn.onClick.AddListener(NextLevel);

    }

    void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}
