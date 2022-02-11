using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwim : MonoBehaviour
{
    Rigidbody rb;
    bool c_pressed;
    bool s_pressed;
    bool swimming;
    [SerializeField] float v;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        v = rb.velocity.y;

        if (Input.GetKey(KeyCode.C) && swimming)
        {
            c_pressed = true;
            rb.drag = 15;
            FixedUpdate();
        }
        if (Input.GetKey(KeyCode.Space) && swimming)
        {
            s_pressed = true;
            rb.drag = 15;
            FixedUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (c_pressed && swimming)
        {
            /*rb.useGravity = true;
            rb.drag = 20;
            pressed = false;*/
            if (rb.velocity.y > -20)
            {
                rb.AddRelativeForce(new Vector3(0, -1f, 0), ForceMode.Impulse);
                c_pressed = false;
            }
        }
        else if (s_pressed && swimming)
        {
            if (rb.velocity.y < 20)
            {
                rb.AddRelativeForce(new Vector3(0, 1f, 0), ForceMode.Impulse);
                s_pressed = false;
            }
        }
    }


    /*private void WaitForFixedUpdate()
    {

        if (dive)
        {
            dive = false;
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            //rb.constraints = RigidbodyConstraints.FreezePositionY;
            /*if (v < -2f)
            {
                dive = true;
            }*/
            if (v <= -2f)
            {
                swimming = true;
                Dive();
            }
            else
            {
                swimming = true;
                rb.velocity = new Vector3(0, 0, 0);
                rb.useGravity = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            swimming = false;
            rb.drag = 0;
            rb.useGravity = true;
        }
    }

    void Dive()
    {
        rb.AddRelativeForce(new Vector3(0, -v / 2f, 0), ForceMode.Impulse);
        rb.drag = 10;
        FixedUpdate();
    }
}
