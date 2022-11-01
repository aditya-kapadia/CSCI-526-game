using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDelay = 5f;
    private bool falling = false;

    [SerializeField] private Rigidbody2D rb;

    private Vector3 origPos;


    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }

    // Update is called once per frame
    public void UpdatePosition()
    {
        origPos = transform.position;
    }

    public void StopFall()
    {
        StopAllCoroutines();
        falling = false;
        rb.bodyType = RigidbodyType2D.Static;
        transform.position = origPos;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Destroy(gameObject.GetComponent("MovePlatform"));
            gameObject.GetComponent<MovePlatform>().enabled = false;

        }
        if (falling == false)
            StartCoroutine(Fall());
    }

    public void TriggerFall()
    {
        if (falling == false)
            StartCoroutine(Fall());

    }

    private IEnumerator Fall()
    {
        falling = true;
        origPos = transform.position;

        yield return new WaitForSeconds(fallDelay);

        // Shake platform back and forth before fall
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

        // Brick falls and game object turns off
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyDelay);
        gameObject.SetActive(false);

        // Reset invisible game object to original position
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = origPos;

        falling = false;
    }
}
