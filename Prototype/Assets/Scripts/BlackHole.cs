using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    // Variables for transport
    private GameObject player;
    [SerializeField] private GameObject destinationBlackHole;
    private bool playerCollide = false;
    public float spinSpeed = 5f;

    // Variable for constant rotation
    public float rotationsPerMinute = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate black hole
        transform.Rotate(0, 0, -6.0f * rotationsPerMinute * Time.deltaTime);

        // Player collides and spins to center of hole and comes out the other hole
        if (playerCollide)
        {
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Vector3 direction =  transform.position - player.transform.position;
            direction = Quaternion.Euler(0, 0, 80) * direction;
            float distanceThisFrame = spinSpeed * Time.deltaTime ;

            player.transform.Translate(direction.normalized * distanceThisFrame, Space.World);

            // Player is close enough to center
            if (Mathf.Abs(transform.position.x - player.transform.position.x) < 0.2
                && Mathf.Abs(transform.position.y - player.transform.position.y) < 0.2)
            {
                StartCoroutine(SendThroughPortal());                
            }
        }
    }

    private IEnumerator SendThroughPortal()
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        player.transform.position = destinationBlackHole.transform.position;
        playerCollide = false;
        destinationBlackHole.GetComponent<BlackHole>().enabled = false;
        yield return new WaitForSeconds(1f);
        destinationBlackHole.GetComponent<BlackHole>().playerCollide = false;
        destinationBlackHole.GetComponent<BlackHole>().enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!playerCollide)
            { 
                playerCollide = true;
                player = other.gameObject;
            }

        }
    }


}
