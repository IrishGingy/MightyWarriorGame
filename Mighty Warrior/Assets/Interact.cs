using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject outline;
    public float TheDistance;

    // Start is called before the first frame update
    void Start()
    {
        outline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        outline.SetActive(true);
    }

    private void OnMouseExit()
    {
        outline.SetActive(false);
    }
}
