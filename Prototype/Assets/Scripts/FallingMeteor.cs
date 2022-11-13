using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMeteor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-20f, -20f);
    }
}
