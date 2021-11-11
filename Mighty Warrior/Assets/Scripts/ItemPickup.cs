using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picked up an item.");
        Destroy(gameObject);
    }
}
