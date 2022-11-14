using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level4_reset : MonoBehaviour
{
       public static int attempts = 0;
       public GameObject startPoint;
    [SerializeField] private Text collectablesText;
    [SerializeField] private Text totalCollectablesText;
    [SerializeField] private GameObject[] collectables;

    [SerializeField] private GameObject[] platforms;


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
             foreach (GameObject collectable in collectables)
            {
                collectable.SetActive(true);
            }



            // Reset collectable counter
            ItemCollector.collectables = 0;
            collectablesText.text = ItemCollector.collectables + " / " + totalCollectablesText.text;
            foreach (GameObject platform in platforms)
            {
            // Bring back falling platforms
            if (platform.CompareTag("FallingPlatform"))
            {
                platform.GetComponent<MovePlatform>().enabled = true;
                platform.SetActive(true);
                platform.GetComponent<FallingPlatform>().StopFall();
            }
            if (platform.CompareTag("FlyingPlatform"))
            {
                platform.SetActive(true);
                platform.GetComponent<level4_immovable>().StopRise();
            }
            }
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
}
