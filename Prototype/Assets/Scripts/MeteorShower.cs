using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShower : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        int numMeteors = 15;
        Vector3 pos = transform.position;
        while (stopSpawning == false)
        {
            
            yield return new WaitForSeconds(10f);
            GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
            foreach (GameObject meteor in meteors)
            {
                Destroy(meteor);
            }

            yield return StartCoroutine(ShakeCamera(2f, 0.25f));
            yield return new WaitForSeconds(0.75f);
            for (int i = 0; i < numMeteors; i++)
            {

                
                pos.x += Random.Range(0f, 20f);
                pos.y += Random.Range(0f, 10f);
                

                Instantiate(spawnee, pos, transform.rotation);
                yield return new WaitForSeconds(0.15f);

                pos = transform.position;
            }
            
        }
    }

    IEnumerator ShakeCamera(float duration, float magnitude)
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        Vector3 orignalPosition = camera.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            camera.transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;

        }
        camera.transform.position = orignalPosition;
        
    }

    public void StopMeteorShower()
    {
        StopAllCoroutines();
        stopSpawning = true;

    }

    public void StartMeteorShower()
    {
        stopSpawning = false;
        StartCoroutine(SpawnCoroutine());
    }

}
