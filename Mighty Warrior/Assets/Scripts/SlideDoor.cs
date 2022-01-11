using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeDoorState()
    {
        if (animator.GetBool("open"))
        {
            animator.SetBool("open", false);
        }
        else
        {
            animator.SetBool("open", true);
        }
    }
}
