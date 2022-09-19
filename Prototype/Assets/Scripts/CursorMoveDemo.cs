using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorMoveDemo : MonoBehaviour
{
    private Scene m_Scene;
    public float speed;
    public Vector3[] positions;
    private int index;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_Scene = SceneManager.GetActiveScene();

        if (m_Scene.name == "Level1")
        {
            transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

            if (transform.position == positions[index])
            {
                
                if (index == positions.Length - 1)
                {
                    transform.position = positions[0];
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
        }
    }
}
