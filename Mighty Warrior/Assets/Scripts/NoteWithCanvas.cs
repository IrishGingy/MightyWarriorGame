using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NoteWithCanvas : MonoBehaviour
{
    public Item item;

    public float TheDistance;
    public Camera playerCam;
    public GameObject image;
    public GameObject manager;

    bool readingNote = false;
    Outline outline;

    private void Start()
    {
        // Makes sure the note is showing on start.
        gameObject.SetActive(true);

        // Makes sure the image of the note is NOT showing on start.
        image.SetActive(false);

        // Gets the outline script (on child object) to enable/disable.
        outline = GetComponentInChildren<Outline>();
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
                playerCam.GetComponent<LPCameraController>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                readingNote = false;
                image.SetActive(false);

                bool wasPickedUp = Inventory.instance.Add(item);
                if (wasPickedUp)
                {
                    Destroy(gameObject);
                }
                manager.GetComponents<AudioSource>()[1].Play();
            }
        }
    }

    // Called by Interact.cs with raycast that looks for specific tags ("note" tag in this case).
    public void ReadingNote()
    {
        // Explicitly making sure the note is NOT currently being read.
        if (readingNote == false)
        {
            Cursor.lockState = CursorLockMode.None;
            playerCam.GetComponent<LPCameraController>().enabled = false;
            readingNote = true;
            //ActionDisplay.SetActive(false);
            //ActionText.SetActive(false);
            
            // Make note's mesh renderer false so it looks like you picked up the note.
            gameObject.GetComponentInChildren<MeshRenderer>().GetComponentInChildren<MeshRenderer>().enabled = false;
            image.SetActive(true);
        }
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            outline.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}