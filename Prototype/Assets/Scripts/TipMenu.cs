using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipMenu : MonoBehaviour
{
    public GameObject tipMenu;
    // Start is called before the first frame update
    void Start()
    {
        if(tipMenu.activeSelf)
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
            if(!tipMenu.activeSelf)
            {
                Time.timeScale = 0f;
                tipMenu.SetActive(true);
            } else
            {
                Time.timeScale = 1f;
                tipMenu.SetActive(false);
            }
        }
        
    }

    public void resume()
    {
        Time.timeScale = 1f;
        tipMenu.SetActive(false);
    }

    public void start()
    {
        Time.timeScale = 1f;
        tipMenu.SetActive(true);
    }
}
