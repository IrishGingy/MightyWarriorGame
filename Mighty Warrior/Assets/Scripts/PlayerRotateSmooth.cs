using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateSmooth : PlayerRotate
{
    // Makes header in inspector (to differentiate between PlayerRotate and PlayerRotateSmooth properties).
    [Header("PlayerRotateSmooth Properties")]
    [SerializeField] private float _smoothTime;
    // Target for SmoothDampAngle
    [SerializeField] private Transform _horizRotHelper;

    // Target for SmoothDampAngle
    private float _vertOld;
    private float _vertAngularVelocity;
    private float _horizAngularVelocity;

    // Syncs on start.
    private void Start() => _horizRotHelper.localRotation = transform.localRotation;

    public override void Rotate()
    {
        _vertOld = vertRot;
        base.Rotate();
    }

    protected override void RotateHorizontal()
    {
        _horizRotHelper.Rotate(Vector3.up * GetHorizontalValue(), Space.Self);
        transform.localRotation = Quaternion.Euler(0f,
                                                   Mathf.SmoothDampAngle(transform.localEulerAngles.y,
                                                                         _horizRotHelper.localEulerAngles.y,
                                                                          ref _horizAngularVelocity,
                                                                          _smoothTime),
                                                   0f);
    }

    protected override void RotateVertical()
    {
        vertRot = Mathf.SmoothDampAngle(_vertOld, vertRot, ref _vertAngularVelocity, _smoothTime);
        base.RotateVertical();
    }
}
