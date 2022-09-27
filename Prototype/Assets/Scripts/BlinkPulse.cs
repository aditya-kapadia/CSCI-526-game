using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkPulse : MonoBehaviour
{

    private Image sr;

    public float minimum = 0.3f;
    public float maximum = 1f;
    public float cyclesPerSecond = 1.0f;
    private float a;
    private bool increasing = true;
    Color color;

    void Start()
    {
        sr = gameObject.GetComponent<Image>();
        color = sr.color;
        a = maximum;
    }



    void Update()
    {
        float t = Time.deltaTime;
        if (a >= maximum) increasing = false;
        if (a <= minimum) increasing = true;
        a = increasing ? a += t * cyclesPerSecond * 2 : a -= t * cyclesPerSecond;
        color.a = a;
        sr.color = color;
    }
}