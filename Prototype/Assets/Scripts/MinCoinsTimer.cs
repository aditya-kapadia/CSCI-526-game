using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinCoinsTimer : MonoBehaviour
{
    // Use this for initialization
    public int destroyTime = 5;
    public int countDown = 5;
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        StartCoroutine(WaitThenDie());
    }

    IEnumerator WaitThenDie() {
        rend.enabled = true;
        var whenAreWeDone = Time.time + 10;
        while (Time.time < whenAreWeDone)
        {
            yield return new WaitForSeconds((float)0.5);
            rend.enabled = !rend.enabled;
        }
        //renderer.enabled = true;
        //yield return new WaitForSeconds(destroyTime);
        rend.enabled = false;
        // Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
