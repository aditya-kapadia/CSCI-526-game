using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkPulse : MonoBehaviour
{
    public Image imageDestination_first;
    public Image imageDestination_second;

    private Image img;

    public float minimum = 0f;
    public float maximum = 1f;
    public float cyclesPerSecond = 1.0f;
    private float a;
    private bool increasing = true;
    bool originalLocation = true;
    Color color;

    void Start()
    {
        img = gameObject.GetComponent<Image>();
        color = img.color;
        a = maximum;
    }

    void Update()
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
        img.color = color;

        if(a <= 0 && gameObject.name == "PlayerInPortalImage")
        {
            if (originalLocation)
            {
                Vector3 newPos = imageDestination_second.transform.position;
                gameObject.transform.position = gameObject.transform.position = newPos;
                    
                originalLocation = false;
            }
            else
            {
                Vector3 newPos = imageDestination_first.transform.position;
                gameObject.transform.position = gameObject.transform.position = newPos;

                originalLocation = true;
            }
        }

    }
}