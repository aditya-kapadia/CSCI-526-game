using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    public GameObject startPoint;
    //public GameObject Death;
    [SerializeField] private Text collectablesText;
    [SerializeField] private Text totalCollectablesText;
    [SerializeField] private GameObject[] collectables;
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private GameObject[] flyingground;


    public static int attempts = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            attempts += 1;
            ItemCollector.gfromcollectable = 0;

            // Move player back to start
            transform.position = startPoint.transform.position;

            // Reactivate all collectables
            foreach (GameObject collectable in collectables)
            {
                collectable.SetActive(true);
            }

            // Reset collectable counter
            ItemCollector.collectables = 0;
            collectablesText.text = ItemCollector.collectables + " / " + totalCollectablesText.text;

            // Make platforms moveable again
            foreach (GameObject platform in platforms)
            {
                platform.GetComponent<MovePlatform>().enabled = true;
                // Bring back falling platforms
                if (platform.CompareTag("FallingPlatform"))
                {
                    platform.SetActive(true);
                    platform.GetComponent<FallingPlatform>().StopFall();
                }
            }

            // foreach (GameObject fg in flyingground)
            // {
            //     // Bring back falling platforms
            //     Debug.Log(trans);
            //     if (fg.CompareTag("Ground"))
            //     {
            //         fg.SetActive(true);
            //         // fg.GetComponent<Ground>().StopFall();
            //     }
            // }


        }
    }
}
