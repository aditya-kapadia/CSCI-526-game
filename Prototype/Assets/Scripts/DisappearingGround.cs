using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingGround : MonoBehaviour
{
    public float toggleTime = 2;
    public float currentTime = 0;
    public bool displayGround = true;
    // Start is called before the first frame update
    void Start()
    {
        displayGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= toggleTime)
        {
            currentTime = 0;
            TogglePlatform();
        }
    }
    void TogglePlatform()
    {
        displayGround = !displayGround;
        //gameObject.SetActive(enabled);
        foreach(Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(displayGround);
        }
    }

}
