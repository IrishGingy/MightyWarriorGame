using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NoteWithCanvas : MonoBehaviour
{
    public Item item;

    public float TheDistance;
    public Camera cam;
    public GameObject image;

    bool readingNote = false;

    private void Start()
    {
        // Makes sure the note is showing on start.
        gameObject.SetActive(true);

        // Makes sure the image of the note is NOT showing on start.
        image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Referencing other script's DistanceFromTarget variable.
        TheDistance = PlayerCasting.DistanceFromTarget;

        // Explicitly making sure that the note IS currently being read.
        if (readingNote)
        {
            // Pressing Q places note in inventory.
            if (Input.GetKeyDown(KeyCode.Q))
            {
                cam.GetComponent<FirstPersonLook>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                readingNote = false;
                image.SetActive(false);

                bool wasPickedUp = Inventory.instance.Add(item);
                if (wasPickedUp)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    // Called by Interact.cs with raycast that looks for specific tags ("note" tag in this case).
    public void ReadingNote()
    {
        // Explicitly making sure the note is NOT currently being read.
        if (readingNote == false)
        {
            cam.GetComponent<FirstPersonLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            readingNote = true;
            //ActionDisplay.SetActive(false);
            //ActionText.SetActive(false);
            
            // Make note's mesh renderer false so it looks like you picked up the note.
            gameObject.GetComponentInChildren<MeshRenderer>().GetComponentInChildren<MeshRenderer>().enabled = false;
            image.SetActive(true);
        }
    }
}