using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

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
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }

    public void UpdatePositions()
    {
        positions[0] = gameObject.transform.position;
        positions[1] = gameObject.transform.position;
        positions[1].y = positions[1].y + 0.25f;
    }
}
