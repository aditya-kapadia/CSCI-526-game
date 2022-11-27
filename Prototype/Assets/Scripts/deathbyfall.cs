using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathbyfall : MonoBehaviour
{
    public static int deaths = 0;
    public PlayerMovement player;
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
            deaths+=1;
            player.deathByFallAnimation();
            // Debug.Log("DF:"+deaths);
        }
    }
}
