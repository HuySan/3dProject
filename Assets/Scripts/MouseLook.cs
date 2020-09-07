using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float rotateHor = 9f;
    public float rotateVert = 9f;
    public float minVert = -80;
    public float maxVert = 50;

    private float rotationX = 0f;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
    }

    void Update()
    {
        if(axes == RotationAxes.MouseX)
        {

            transform.Rotate(0, Input.GetAxis("Mouse X") * rotateHor, 0);
        }else if(axes == RotationAxes.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * rotateVert;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotationX, rotationY);

        }
        else
        {
 
            rotationX -= Input.GetAxis("Mouse Y") * rotateVert;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * rotateHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(rotationX, rotationY);
        }
    }
}
