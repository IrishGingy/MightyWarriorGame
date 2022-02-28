using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);
        objectPooler.SpawnFromPool("Sphere", transform.position, Quaternion.identity);
    }
}
