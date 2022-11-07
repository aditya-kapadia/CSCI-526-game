using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseScript : MonoBehaviour
{
    // private float RiseDelay = 0.11f;
    private float destroyDelay = 5f;
    private bool Rising = false;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 origPos;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }
    public void UpdatePosition()
    {
        origPos = transform.position;
    }

    public void StopRise()
    {
        StopAllCoroutines();
        Rising = false;
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
        if (Rising == false)
            StartCoroutine(Rise());
    }

    public void TriggerRise()
    {
        if (Rising == false)
            StartCoroutine(Rise());

    }

    private IEnumerator Rise()
    {
        Rising = true;
        origPos = transform.position;

        // yield return new WaitForSeconds(RiseDelay);

        // Shake platform back and forth before Rise
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

        // Brick Rises and game object turns off
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyDelay);
        gameObject.SetActive(false);

        // Reset invisible game object to original position
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.position = origPos;

        Rising = false;
    }
}
