using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSceneThree : MonoBehaviour
{
    float speed = 5;
    float maxPosZ = 8;
    float minPosZ = -8;

    int direction = 1;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, speed * direction *Time.deltaTime);
        bool bounced = false;
        if (transform.position.z > maxPosZ || transform.position.z < minPosZ)
        {
            direction = -direction;
            bounced = true;
        }
        if(bounced)
        {
            transform.Translate(0, 0, speed * direction * Time.deltaTime);
        }
    }
}
