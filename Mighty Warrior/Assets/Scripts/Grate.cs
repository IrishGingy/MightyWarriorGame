using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grate : MonoBehaviour
{
    public bool open = false;
    public float grateOpenAngle = -90f;
    public float grateCloseAngle = 0f;
    public float smooth = 5f;

    bool blocking = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            Quaternion targetRotationO = Quaternion.Euler(grateOpenAngle, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationO, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotationC = Quaternion.Euler(grateCloseAngle, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationC, smooth * Time.deltaTime);
        }
    }

    public void ChangeGrateState()
    {
        // Flips open bool
        open = !open;
    }
}
