using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDelay = 2f;
    private bool falling = false;

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
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject.GetComponent("MovePlatform"));
        }
        if (falling == false)
            StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        falling = true;

        yield return new WaitForSeconds(fallDelay);

        // Shake platform back and forth before fall
        Vector3 origPos = transform.position;
        for (int i = 0; i < 7; i++)
        {
            transform.position = new Vector3(origPos.x - 0.12f, origPos.y);
            yield return new WaitForSeconds(0.09f);
            transform.position = origPos;
            yield return new WaitForSeconds(0.09f);
            transform.position = new Vector3(origPos.x + 0.12f, origPos.y);
            yield return new WaitForSeconds(0.09f);
            transform.position = origPos;
        }
        
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);

        falling = false;
    }
}
