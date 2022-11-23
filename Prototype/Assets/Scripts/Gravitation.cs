using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    public Transform player;
    Rigidbody2D playerbody;
    public float influencerange;
    public float intensity;
    public float dist2player;
    Vector2 pullforce;
    // [SerializeField] private float gravitationalForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        playerbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dist2player = Vector2.Distance(player.position, transform.position);
        if(dist2player<=influencerange)
        {
            pullforce = (transform.position - player.position).normalized/(dist2player*intensity);
            pullforce = pullforce*50;
            // Debug.Log(pullforce);
            playerbody.AddForce(pullforce, ForceMode2D.Force);
        }
        // var directionOfBirdFromPlanet = (transform.position - player.position).normalized;

            // Adds the force towards the center
        // playerbody.AddForce(directionOfBirdFromPlanet * gravitationalForce);
    }
}
