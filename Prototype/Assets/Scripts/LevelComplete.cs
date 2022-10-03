using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public sendtogform sg;
    public void Setup()
    {
        sg.Send();
        MovePlatform.platformsUsed = 0;
        DeathScript.attempts = 0;
        ItemCollector.gfromcollectable = 0;
        sendtogform.level = 2;
        gameObject.SetActive(true);
    }

}
