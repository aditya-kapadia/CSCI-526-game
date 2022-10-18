using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinCoinsTimer : MonoBehaviour
{
    // Use this for initialization
    public int destroyTime = 5;
    void Start()
    {
        StartCoroutine(WaitThenDie());
    }

    IEnumerator WaitThenDie() {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
