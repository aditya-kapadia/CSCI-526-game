using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level4_reset : MonoBehaviour
{
       public static int attempts = 0;
    [SerializeField] private Text collectablesText;
    [SerializeField] private Text totalCollectablesText;

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
            //  foreach (GameObject collectable in collectables)
            // {
            //     collectable.SetActive(true);
            // }

            // Reset collectable counter
            ItemCollector.collectables = 0;
            collectablesText.text = ItemCollector.collectables + " / " + totalCollectablesText.text;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
}
