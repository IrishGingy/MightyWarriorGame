using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=3QK-fe52od0&list=PLKklF7YNi0lMIF6Iw4_YI_58bsyj5FTE8&index=6 (Single Sapling Games First Person Character Controller Tutorial Video)
public class LPPlayerController : MonoBehaviour
{
    // Movement
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    // Gravity
    [Header("Gravity")]
    [SerializeField] private float gravity;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool grounded = false;
    private Vector3 velocity = Vector3.zero;

    // Animation
    private Animator anim;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void Update()
    {
        HandleIsGrounded();
        HandleJumping();
        HandleGravity();

        // Because this changes moveSpeed which is used in HandleMovement,
        // HandleRunning needs to be called before HandleMovement.
        HandleRunning();
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Right and left (on plane) which is triggered by d and a keys.
        float moveX = Input.GetAxisRaw("Horizontal");
        // Up and down (on plane) which is triggered by w and s keys.
        float moveZ = Input.GetAxisRaw("Vertical");

        // moveX and moveZ are negative because the camera is flipped to 180 to fit direction of hands model (MIGHT NEED TO CHANGE LATER).
        moveDirection = new Vector3(-moveX, 0, -moveZ);
        moveDirection = moveDirection.normalized;
        // Transforms from local to world space (so you move where you look).
        moveDirection = transform.TransformDirection(moveDirection);

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void HandleRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed;
        }
    }

    private void HandleAnimations()
    {
        // Movement animations.
        if (moveDirection == Vector3.zero)
        {

        }
    }

    private void HandleIsGrounded()
    {
        // Creates sphere at bottom of player to detect ground layer collision to allow jumping.
        grounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
    }

    private void HandleGravity()
    {
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void GetReferences()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void InitVariables()
    {
        moveSpeed = walkSpeed;
    }
}
