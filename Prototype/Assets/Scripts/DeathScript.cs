using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject Player;

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
        if (other.gameObject.CompareTag("Player"))
        {
            attempts += 1;
            Debug.Log("Attempts: "+attempts);
            MovePlatform.platformsUsed = 0;
            //Player.transform.position = startPoint.transform.position;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
