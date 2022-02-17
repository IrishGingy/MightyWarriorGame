using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public float TheDistance;
    public GameObject panel;
    public GameObject player;

    bool holdingPhone = false;
    Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        // Makes sure the note is showing on start.
        gameObject.SetActive(true);

        // Makes sure the phone dialogue panel is NOT showing on start.
        panel.SetActive(false);

        // Gets the outline script (on child object) to enable/disable.
        outline = GetComponentInChildren<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        // Referencing other script's DistanceFromTarget variable.
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            outline.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpPhone();
            }
        }
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    void PickUpPhone()
    {
        // Explicitly making sure the note is NOT currently being read.
        if (holdingPhone == false)
        {
            Cursor.lockState = CursorLockMode.None;
            player.transform.Find("First Person Movement").gameObject.SetActive(false);
            player.GetComponentInChildren<FirstPersonLook>().enabled = false;
            player.GetComponentInChildren<Interact>().enabled = false;
            player.GetComponentInChildren<Zoom>().enabled = false;

            // Make note's mesh renderer false so it looks like you picked up the note.
            gameObject.GetComponentInChildren<MeshRenderer>().GetComponentInChildren<MeshRenderer>().enabled = false;
            panel.SetActive(true);

            holdingPhone = true;
        }
    }
}
