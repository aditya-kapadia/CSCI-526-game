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
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject playerShield;
    [SerializeField] private GameObject shieldPowerup;

    private bool removingShield;

    public static int attempts = 0;
    // Start is called before the first frame update
    void Start()
    {
        removingShield = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            StartCoroutine(ResetLevel());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Meteor"))
        {
            if (playerShield.activeSelf == false)
            {
                // Destroy all previously spawnd meteor game objects
                GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
                foreach (GameObject meteor in meteors)
                {
                    Destroy(meteor);

                }

                StartCoroutine(ResetLevel());
            }
            else
            {
                StartCoroutine(RemoveShield());
            }


        }
        // If player hits enemy
        else if (other.gameObject.CompareTag("Death"))
        {
            if (playerShield)
            {
                if (playerShield.activeSelf == false)
                    StartCoroutine(ResetLevel());
                else
                {
                    StartCoroutine(RemoveShield());
                }
            }
        }
    }

    IEnumerator ResetLevel()
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

        // Resetting meteor shower components
        if (playerShield)
            playerShield.SetActive(false);
        if (shieldPowerup)
            shieldPowerup.GetComponent<ActivateShield>().ResetPowerupPosition();
        if (spawner)
        {
            spawner.GetComponent<MeteorShower>().StopMeteorShower();
            yield return new WaitForSeconds(2f);
            spawner.GetComponent<MeteorShower>().StartMeteorShower();
        }
        
    }

    IEnumerator RemoveShield()
    {
        if (!removingShield)
        {
            removingShield = true;

            // Start blinking shield for 5 sec to signal to player that it will disappear soon
            playerShield.GetComponent<ActivateShield>().BlinkShield();
            yield return new WaitForSeconds(5f);

            // Turn shield off
            playerShield.GetComponent<ActivateShield>().ShieldBlinking = false;
            playerShield.SetActive(false);

            // Reinit shield powerup in random location
            yield return new WaitForSeconds(5f);
            shieldPowerup.GetComponent<ActivateShield>().ReinitPowerup();

            removingShield = false;
        }
        
    }


}
