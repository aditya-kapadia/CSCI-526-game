
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class sendtogform : MonoBehaviour{
    // Session_Id
    long sessionID;
    // Brick_Count
    int brickCount;
    int attempts;
    string URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSeQgVynm6jwn0omRZByKhqf1KzhGG8tTdZ1RYtjwjg1vAs_Bg/formResponse";

    
    public static int level = 1;
    public DeathScript ds;
    void Start()
    {
        // attempts = ds.attempts;
    }
    public void Send()
    {
        sessionID = DateTime.Now.Ticks;
        brickCount = MovePlatform.platformsUsed;
        Debug.Log("BC:"+brickCount);
        attempts = DeathScript.attempts;
        Debug.Log("Attempts in sendform:"+attempts);
            attempts++;

        Debug.Log("Send");
        StartCoroutine(Post(sessionID.ToString(),brickCount.ToString(), attempts.ToString(), level.ToString()));
    }

    IEnumerator Post(string s1, string s2,string s3, string s4)
    {
        Debug.Log("Post");
        WWWForm form = new WWWForm();
        form.AddField("entry.252900137",s1);
        form.AddField("entry.1830174599",s2);
        form.AddField("entry.559368451",s3);
        form.AddField("entry.1720030055",s4);
        UnityWebRequest www = UnityWebRequest.Post(URL,form);
        yield return www.SendWebRequest();
        www.Dispose();
    }

    
}