using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int collectables = 0;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            collectables++;
            collectablesText.text = "Collectables: " + collectables + " / " + totalCollectablesText.text;
            Destroy(other.gameObject);
        }
    }
}
