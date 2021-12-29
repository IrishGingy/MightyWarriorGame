using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public bool open = false;
    public Vector3 openPosition = new Vector3();
    public Vector3 closedPosition = new Vector3();
    public float smooth = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            transform.localPosition = Vector3.Slerp(new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), transform.localPosition, smooth * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, new Vector3(transform.localPosition.x-1, transform.localPosition.y, transform.localPosition.z), smooth * Time.deltaTime);
        }
    }

    public void ChangeDrawerState()
    {
        // Flips open bool
        open = !open;
    }
}
