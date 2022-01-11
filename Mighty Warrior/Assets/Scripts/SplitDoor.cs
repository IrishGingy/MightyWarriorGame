using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitDoor : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!animator.GetBool("open"))
        {
            animator.SetBool("open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if (animator.GetBool("open"))
        {
            animator.SetBool("open", false);
        }
    }
}
