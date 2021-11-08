using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerMove), typeof(PlayerRotate))] 
public class Player : MonoBehaviour
{
    [SerializeField] Transform respawnPoint;
    public float timeRemaining = 2f;

    private CharacterController controller;
    private PlayerMove _move;
    private PlayerRotate _rotate;
    private PlayerRotate _rotateSmooth;
    private PlayerRotate _currentRotate;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        _move = GetComponent<PlayerMove>();
        _rotate = GetComponents<PlayerRotate>()[0];
        _rotateSmooth = GetComponents<PlayerRotate>()[1];
        _currentRotate = _rotateSmooth;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _move.Move();
        _currentRotate.Rotate();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collided with obstacle.");
            controller.detectCollisions = false;
            Debug.Log("Collisions off");
            gameObject.transform.position = respawnPoint.position;
            while (timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;
            }
            timeRemaining = 0f;
            controller.detectCollisions = true;
            Debug.Log("Collisions back on!");
        }
    }
}
