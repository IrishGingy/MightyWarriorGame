using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float interactDistance = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.GetComponent<Door>().ChangeDoorState();
                }
            }

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Grate"))
                {
                    hit.collider.GetComponent<Grate>().ChangeGrateState();
                }
            }

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Note"))
                {
                    hit.collider.GetComponent<NoteWithCanvas>().ReadingNote();
                }
            }

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Drawer"))
                {
                    hit.collider.GetComponent<Drawer>().ChangeDrawerState();
                }
            }

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("SlideDoor"))
                {
                    hit.collider.GetComponent<SlideDoor>().ChangeDoorState();
                }
            }
        }
    }
}
