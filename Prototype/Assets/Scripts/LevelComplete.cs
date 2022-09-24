using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public sendtogform sg;
    public void Setup()
    {
        sg.Send();
        gameObject.SetActive(true);
    }

}
