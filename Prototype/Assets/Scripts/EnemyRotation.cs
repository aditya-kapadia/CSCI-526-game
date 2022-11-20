using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public Transform RotationCenter;
    public float angularSpeed, rotationRadius;
    private float posX, posY, angle = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        posX = RotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = RotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;

        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;
        if(angle >= 360)
        {
            angle = 0;
        }

    }


}
