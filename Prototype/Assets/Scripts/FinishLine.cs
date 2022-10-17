using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public LevelComplete LevelComplete;

    [SerializeField] private Text collectablesText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        string[] coinSummary = GameObject.FindWithTag("Collectables Text").GetComponent<Text>().text.Split(" /");
        double avgCoinsCollected = double.Parse(coinSummary[0]) / double.Parse(coinSummary[1]);
        if (avgCoinsCollected >= 0.1 && other.gameObject.CompareTag("Goal"))
        {
            Time.timeScale = 0f;
            LevelComplete.Setup(avgCoinsCollected);


        }
    }
}
