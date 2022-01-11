using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeDrawerState()
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
