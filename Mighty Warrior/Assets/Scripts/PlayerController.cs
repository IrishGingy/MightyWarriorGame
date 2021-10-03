using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // What is target?                                              WHAT IS THIS?
    public GameObject target;
    public Camera playerCam;

    private float x = 0f;
    private float y = 0f;
    // Smoothing of the camera on x and y axes.
    private float xSmooth= 0f;
    private float ySmooth= 0f;
    // Not really sure what this does yet :/                        WHAT DOES THIS DO?
    public float smoothTime = 0.8f;
    // Up and down speed of the camera.
    private float xSpeed = 0.0f;
    // Left and right speed of the camera.
    private float ySpeed = 0.0f;
    // Quaternion that rotates the camera.
    private Quaternion rotateCam;
    // What direction the camera is looking.
    private Quaternion lookDirection;

    //public bool getLookAroundActive;
    //public bool setLookAroundActive = false;
    //private bool lookButtonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (target)
        {
            transform.position = target.transform.position;
        }
    }

    public void ActiveLookAround()
    {
        
    }

    private void FixedUpdate()
    {
        x += Input.GetAxis("Mouse X") * 0.2f;
        y -= Input.GetAxis("Mouse Y") * 0.2f;

        x = ClampAngle(x, -20, 20);
        y = ClampAngle(y, -20, 10);

        xSmooth = x;
        ySmooth = Mathf.SmoothDamp(ySmooth, y, ref ySpeed, smoothTime);

        rotateCam = Quaternion.Euler(ySmooth, xSmooth, 0);

        lookDirection = transform.rotation * rotateCam;
        transform.rotation = Quaternion.Slerp(lookDirection, target.transform.rotation, 0.3f);
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}
