using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using ItemCollector;
// using static MyNamespace.ItemCollector;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour
{
    public ItemCollector itemCollector;
    public void Setup()
    {
        if (itemCollector.ReturnCollectables()==3)
        {
            gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}