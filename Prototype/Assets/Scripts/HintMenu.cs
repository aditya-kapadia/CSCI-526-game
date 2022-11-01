using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintMenu : MonoBehaviour
{
    public GameObject hintMenu;
    // Start is called before the first frame update
    void Start()
    {
        if(hintMenu.activeSelf)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!hintMenu.activeSelf)
            {
                Time.timeScale = 0f;
                hintMenu.SetActive(true);
            } else
            {
                Time.timeScale = 1f;
                hintMenu.SetActive(false);
            }
        }
        
    }

    public void resume()
    {
        Time.timeScale = 1f;
        hintMenu.SetActive(false);
    }
}
