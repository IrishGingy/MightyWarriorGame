using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool open = false;
    public float doorOpenAngle = -90f;
    public float doorCloseAngle = 0f;
    public float smooth = 2f;

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
            Quaternion targetRotationO = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationO, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotationC = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationC, smooth * Time.deltaTime);
        }
    }

    public void ChangeDoorState()
    {
        // Flips open bool
        open = !open;
    }

    public void Locked()
    {
        // Shows locked text
        string ht = "Locked. I should look for the key.";
        HelpText helpText = new HelpText();
        HelpText h = helpText;
        h.Display(ht);
    }
}
