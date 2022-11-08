using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateShield : MonoBehaviour
{
    [SerializeField] public GameObject playerShield;
    private bool ShieldBlinking = false;
    public SpriteRenderer sprite;

    public float minimum = 0f;
    public float maximum = 1f;
    public float cyclesPerSecond = 2.0f;
    private float a;
    private bool increasing = true;
    Color color;

    // Start is called before the first frame update
    void Start()
    {
        playerShield.SetActive(false);
        sprite = playerShield.GetComponent<SpriteRenderer>();
        color = sprite.color;
        a = maximum;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShieldBlinking)
        {
            float t = 0;
            if (Time.timeScale == 0)
            {
                t = 0.005f;
            }
            else
            {
                t = Time.deltaTime;
            }


            if (a >= maximum) increasing = false;
            if (a <= minimum) increasing = true;
            a = increasing ? a += t * cyclesPerSecond * 2 : a -= t * cyclesPerSecond;
            color.a = a;
            sprite.color = color;
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerShield.SetActive(true);
            gameObject.SetActive(false);

        }
    }

    public void BlinkShield()
    {
        ShieldBlinking = true;
    }

}
