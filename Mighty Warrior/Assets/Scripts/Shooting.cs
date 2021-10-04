using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // obstacle that is shot out.
    [SerializeField] GameObject obstacle;

    private float[] pattern;
    private float z = 0f;
    private float y = 0f;

    // Every once in a while a homing obstacle that follows the player?
    private void Start()
    {
        z = Random.Range(0f, gameObject.transform.localScale.z);
        y = Random.Range(0f, gameObject.transform.localScale.y);
        pattern[0] = z;
        pattern[1] = y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
