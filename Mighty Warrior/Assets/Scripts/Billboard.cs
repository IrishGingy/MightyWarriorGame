using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes sprites constantly look at the camera.
/// </summary>
public class Billboard : MonoBehaviour
{
    [SerializeField] Camera cam;

    /// <summary>
    /// Aligns the transform rotation of the object with the transform forward of the player's camera.
    /// </summary>
    void LateUpdate()
    {
        transform.forward = cam.transform.forward;
    }
}
