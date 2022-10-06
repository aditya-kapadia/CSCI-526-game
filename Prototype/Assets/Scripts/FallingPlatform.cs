using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 0.6f;
    private float destroyDelay = 2f;
    //private bool shaking = false;

    [SerializeField] private Rigidbody2D rb;
    

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
        StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {

        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
