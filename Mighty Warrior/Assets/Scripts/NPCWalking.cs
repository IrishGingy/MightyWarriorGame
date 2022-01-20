using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalking : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartWalking();
        }
    }

    public void StartWalking()
    {
        if (animator.GetBool("walking"))
        {
            animator.SetBool("walking", false);
        }
        else
        {
            animator.SetBool("walking", true);
        }
    }
}
