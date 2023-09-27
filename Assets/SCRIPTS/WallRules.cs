using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRules : MonoBehaviour
{
    public LayerMask playerLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            if(playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
            }
        }
    }
}
