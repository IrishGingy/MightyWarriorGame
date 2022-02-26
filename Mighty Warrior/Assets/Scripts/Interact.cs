using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float interactDistance = 5f;
    public bool HasKey = false;
    public Item key;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                // Door
                if (hit.collider.CompareTag("Door"))
                {
                    if (HasKey)
                    {
                        hit.collider.GetComponent<Door>().ChangeDoorState();
                    }
                    else
                    {
                        hit.collider.GetComponent<Door>().Locked();
                        Debug.Log("This door needs a key!");
                    }
                }

                // Grate
                if (hit.collider.CompareTag("Grate"))
                {
                    hit.collider.GetComponent<Grate>().ChangeGrateState();
                }

                // Note
                if (hit.collider.CompareTag("Note"))
                {
                    if (hit.collider.GetComponentInChildren<NoteWithCanvas>().item.name == "To-Do List")
                    {
                        Debug.Log("Picked up Key");
                        HasKey = true;
                        Inventory.instance.Add(key);
                    }
                    hit.collider.GetComponent<NoteWithCanvas>().ReadingNote();
                }

                // Drawer
                if (hit.collider.CompareTag("Drawer"))
                {
                    hit.collider.GetComponent<Drawer>().ChangeDrawerState();
                }

                // Slide Door
                if (hit.collider.CompareTag("SlideDoor"))
                {
                    hit.collider.GetComponent<SlideDoor>().ChangeDoorState();
                }

                // Consumable
                if (hit.collider.CompareTag("Consumable"))
                {
                    hit.collider.GetComponent<Consumable>().Consume();
                }
            }
        }
    }
}
