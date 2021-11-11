using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isClose = false;
    Transform player;

    private void Update()
    {
        if (isClose)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Debug.Log("INTERACT");
            }
        }
    }

    public void Close(Transform playerTransform)
    {
        isClose = true;
        player = playerTransform;
    }

    public void NotClose()
    {
        isClose = false;
        player = null;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
