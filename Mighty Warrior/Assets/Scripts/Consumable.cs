using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public Item item;
    public GameObject manager;

    public float TheDistance;

    // Update is called once per frame
    void Update()
    {
        // Referencing other script's DistanceFromTarget variable.
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    public void Consume()
    {
        /*bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destory(gameObject);
        }*/

        // make audiosources in game manager into dictionary?
        manager.GetComponents<AudioSource>()[0].Play();
        Destroy(gameObject);
    }
}
