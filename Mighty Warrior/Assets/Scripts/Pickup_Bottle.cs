using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Bottle : MonoBehaviour
{
    public Item item;

    public float TheDistance;
    //public GameObject ActionDisplay;
    //public GameObject ActionText;
    //public GameObject UINote;
    public GameObject ThePlayer;
    //public GameObject NoteCam;
    public GameObject bottle;
    //public Material[] materials;
    //public Canvas canvas;

    bool readingNote;
    Renderer rend;
    int mat = 0;

    private void Start()
    {
        rend = bottle.GetComponent<Renderer>();
        //rend.material = materials[mat];
    }

    // Update is called once per frame
    void Update()
    {
        // Referencing other script's DistanceFromTarget variable.
        TheDistance = PlayerCasting.DistanceFromTarget;
        /*
        if (Input.GetKeyDown(KeyCode.A) && mat > 0)
        {
            mat--;
            rend.material = materials[mat];
        }
        if (Input.GetKeyDown(KeyCode.D) && mat < materials.Length - 1)
        {
            mat++;
            rend.material = materials[mat];
        }
        */
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
            //readingNote = false;
            //ThePlayer.SetActive(true);
            //NoteCam.SetActive(false);
            //UINote.SetActive(false);
            //ActionDisplay.SetActive(true);
            //ActionText.SetActive(true);
        //}
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            //rend.material = materials[1];

            if (Input.GetKeyDown(KeyCode.E))
            {
                Pickup();
            }
        }
}

    private void OnMouseExit()
    {
        //rend.material = materials[0];

        //ActionDisplay.SetActive(false);
        //ActionText.SetActive(false);
    }

    private void Pickup()
    {
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(bottle);
        }
        //rend.material = materials[0];
        //readingNote = true;

        //ActionDisplay.SetActive(false);
        //ActionText.SetActive(false);
        //UINote.SetActive(true);
        //NoteCam.SetActive(true);
        //ThePlayer.SetActive(false);
    }
}