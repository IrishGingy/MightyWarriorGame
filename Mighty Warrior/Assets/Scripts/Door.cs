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

    public GameObject ht;
    public HelpText helpText;

    DisplayHelpText script;
    bool blocking = false;

    // Start is called before the first frame update
    void Start()
    {
        ht.SetActive(false);
        script = ht.GetComponent<DisplayHelpText>();
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
        //helpText.Display();
        //HelpText ht = ScriptableObject.CreateInstance<HelpText>();
        script.helpText = helpText;
        script.helpText.text = helpText.text;
        script.Display();
    }

    public void ChangeHelpText()
    {

    }
}
