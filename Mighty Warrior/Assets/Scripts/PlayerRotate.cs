using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    // Makes header in inspector (to differentiate between PlayerRotate and PlayerRotateSmooth properties).
    [Header("PlayerRotate Properties")]
    // Used for rotating the Camera Holder.
    [SerializeField] private Transform _cameraHolder;
    // Rotation speed.
    [SerializeField] private float _speed;
    // Limits the vertical rotation.
    [SerializeField] private float _rotationLimit;

    // Later the child of this class needs to use this variable (keeps track of vertical rotation).
    protected float vertRot;

    public virtual void Rotate()
    {
        // Subtracted because mouse Y float value is inverted.
        vertRot -= GetVerticalValue();
        // Clamps the vertical rotation using ternary conditional operator (if condition true use first value, if not use the second value (after the colon)).
        vertRot = vertRot <= -_rotationLimit ? -_rotationLimit :
                  vertRot >= _rotationLimit ? _rotationLimit :
                  vertRot;

        // Rotates the player model vertically and horizontally.
        RotateVertical();
        RotateHorizontal();
    }

    // Gets float vertical mouse value.
    protected float GetVerticalValue() => Input.GetAxis("Mouse Y") * _speed * Time.deltaTime;
    // Gets float horizontal mouse value.
    protected float GetHorizontalValue() => Input.GetAxis("Mouse X") * _speed * Time.deltaTime;
    protected virtual void RotateVertical() => _cameraHolder.localRotation = Quaternion.Euler(vertRot, 0f, 0f);
    protected virtual void RotateHorizontal() => transform.Rotate(Vector3.up * GetHorizontalValue());
}
