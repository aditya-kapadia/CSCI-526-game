
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class sendtogform : MonoBehaviour{
    // Session_Id
    DateTime sessionID;
    public static DateTime startSessionID;
    public static DateTime pauseTime;
    // Brick_Count
    int brickCount;
    int attempts;
    int collectables;
    string URL = "https://docs.google.com/forms/u/1/d/e/1FAIpQLSeQgVynm6jwn0omRZByKhqf1KzhGG8tTdZ1RYtjwjg1vAs_Bg/formResponse";

    int falldeath;
    int enemydeath;
    public static int level = 1;
    public DeathScript ds;
    public ItemCollector ic;
    void Start()
    {
        
    }
    public void Send()
    {
        falldeath = deathbyfall.deaths;
        enemydeath = deathbycollision.deaths;
        // Debug.Log("FD:"+falldeath);
        // Debug.Log("ED:"+enemydeath);
        
        sessionID = DateTime.Now;
        TimeSpan diff = sessionID - startSessionID;
        double seconds = Math.Abs(diff.TotalSeconds - SettingsMenu.pauseTime.TotalSeconds);
        // Debug.Log("Time in each level:"+(sessionID.SubtractstartSessionID).Seconds);
        brickCount = MovePlatform.platformsUsed;
        // Debug.Log("BC:"+brickCount);
        attempts = DeathScript.attempts;
        // Debug.Log("Attempts in sendform:"+attempts);
        attempts++;
        collectables = ItemCollector.gfromcollectable;
        // Debug.Log("Send");
        deathbyfall.deaths=0;
        deathbycollision.deaths=0;
        StartCoroutine(Post(sessionID.Ticks.ToString(),brickCount.ToString(), attempts.ToString(), level.ToString(), collectables.ToString(), enemydeath.ToString(), falldeath.ToString(), seconds.ToString()));
    }

    IEnumerator Post(string s1, string s2,string s3, string s4, string s5, string s6, string s7, string s8)
    {
        // Debug.Log("Post");
        WWWForm form = new WWWForm();
        // Debug.Log(s1+s2+s3+s4+s5);
        form.AddField("entry.252900137",s1);
        form.AddField("entry.1830174599",s2);
        form.AddField("entry.559368451",s3);
        form.AddField("entry.1720030055",s4);
        form.AddField("entry.953594840",s5);
        form.AddField("entry.1816916965",s6);
        form.AddField("entry.1642617224",s7);
        form.AddField("entry.86693865",s8);        
        UnityWebRequest www = UnityWebRequest.Post(URL,form);
        yield return www.SendWebRequest();
        www.Dispose();
    }

   
}