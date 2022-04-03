using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMovement : MonoBehaviour
{
    public float degrees = 0;

    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    private Transform endMarker;

    // Movement speed in units per second.
    public float speed = 0.1f;

    private float timeCount = 0.0f;
    private bool forward;

    private float x;
    private float y;
    private float z;

    private void Start()
    {
        endMarker = startMarker;
        forward = false;
    }

    void Update()
    {
        x = transform.localPosition.x;
        y = transform.localPosition.y;
        z = transform.localPosition.z;

        // move forward
        if (!forward && Input.GetKeyDown(KeyCode.W))
        {
            if (transform.rotation.y == 0)
            {
                z += 2.5f;
            }
            if (transform.localEulerAngles.y == 90)
            {
                x += 2.5f;
            }
            if (transform.localEulerAngles.y == 180)
            {
                z -= 2.5f;
            }
            if (transform.localEulerAngles.y == 270)
            {
                x -= 2.5f;
            }
            transform.localPosition = new Vector3(x, y, z);
            forward = true;
        }

        // move back
        if (forward && Input.GetKeyDown(KeyCode.S))
        {
            if (transform.rotation.y == 0)
            {
                z -= 2.5f;
            }
            if (transform.localEulerAngles.y == 90)
            {
                x -= 2.5f;
            }
            if (transform.localEulerAngles.y == 180)
            {
                z += 2.5f;
            }
            if (transform.localEulerAngles.y == 270)
            {
                x += 2.5f;
            }
            transform.localPosition = new Vector3(x, y, z);
            forward = false;
        }

        if (!forward && Input.GetKeyDown(KeyCode.D))
        {
            endMarker.Rotate(new Vector3(0, 90, 0));
            transform.rotation = Quaternion.Slerp(startMarker.rotation, endMarker.rotation, timeCount); 
            timeCount += Time.deltaTime;
        }
        if (!forward && Input.GetKeyDown(KeyCode.A))
        {
            endMarker.Rotate(new Vector3(0, -90, 0));
            transform.rotation = Quaternion.Slerp(startMarker.rotation, endMarker.rotation, timeCount); 
            timeCount += Time.deltaTime;
        }
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // move right
            gameObject.transform.Rotate(new Vector3(0, 90, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // move left
        }
    }*/
}
