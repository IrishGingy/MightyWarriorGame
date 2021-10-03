using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _player;
    // Calculates which direction player should go.
    private Vector3 _moveDir;

    private void Awake() => _player = GetComponent<CharacterController>();

    public void Move()
    {
        // Moves player to correct sides (transform.right is negative when going left) dependent on player look direction.
        _moveDir = ((transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"))) * _speed;
        // possibly redu
        _player.Move(_moveDir * Time.deltaTime);
    }
}
