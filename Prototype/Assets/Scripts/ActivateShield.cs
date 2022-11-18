using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateShield : MonoBehaviour
{
    [SerializeField] public GameObject playerShield;
    [SerializeField] public GameObject shieldPowerup;
    public Vector3[] shieldSpawnPositions;
    public bool ShieldBlinking = false;
    private Vector3 startPos_powerup;
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
        startPos_powerup = shieldPowerup.transform.position;
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
                //t = 0.005f;
                t = 0;
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

        else
        {
            color.a = 1f;
            sprite.color = color;
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerShield.SetActive(true);
            shieldPowerup.SetActive(false);
        }
    }

    public void BlinkShield()
    {
        ShieldBlinking = true;
    }

    public void ReinitPowerup()
    {
        if (!shieldPowerup.activeSelf)
        {
            Vector3 pos = shieldSpawnPositions[Random.Range(0, shieldSpawnPositions.Length)];
            shieldPowerup.transform.position = pos;
            shieldPowerup.GetComponent<EnemyMovement>().UpdatePositions();
            shieldPowerup.SetActive(true);
        }
    }

    public void ResetPowerupPosition()
    {
        shieldPowerup.transform.position = startPos_powerup;
        shieldPowerup.GetComponent<EnemyMovement>().UpdatePositions();
        shieldPowerup.SetActive(true);
    }


}
