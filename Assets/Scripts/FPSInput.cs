using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 6f;
    private CharacterController charControl;

    public float gravity = -9.8f;

    bool live;

    void Start()
    {
        live = true;
        charControl = GetComponent<CharacterController>();
    }


    void Update()
    {
        Vector3 movement = new Vector3(0,0,0);
        if (live)
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
           
            movement = new Vector3(deltaX, 0, deltaZ);
        }
            movement = Vector3.ClampMagnitude(movement, speed);
           movement.y = gravity;

            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);


            charControl.Move(movement);


        
    }
    public void SetLive(bool _live)
    {
        live = _live;
    }
}
