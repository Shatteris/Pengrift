using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PENGUIN : MonoBehaviour
{
    public float jumpforce = 10f;
    public float jumpThreshold = 3f;
    public float jumpcooldown = 1f;

    private bool canJump = true;
    private bool isGrounded = true;
    private Rigidbody playerBody;

    void Start()
    {
        if (!Input.gyro.enabled)
        {
            Debug.LogError("Gyroscope not enabled");
            return;
        }

        playerBody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Vector3 Accel = Input.acceleration;

        Move();
        isGrounded = Grounded();
        Jump();
    }

    private void Move()
    {
        float directionInput = Input.acceleration.x;
        if (directionInput > 0.2f)
        {
            directionInput = 1f;
        }
        if (directionInput < -0.2)
        {
            directionInput = -1f;
        }
        if (directionInput < 0.2f && directionInput > -0.2f)
        {
            directionInput = 0f;
        }
    }

    //Jump--------------------------------------------------------------------------------------
    private bool Grounded()
    {
        float rayLength = 0.01f;
        Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;

        if (Physics.Raycast(rayOrigin, Vector3.down, rayLength))
        {
            return true;
        }
        else { return false; }
    }


    private void Jump()
    {
        float jumpInput = Input.acceleration.y;

        if (jumpInput > 0.3f && isGrounded && canJump)
        {
            playerBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isGrounded = false;
            canJump = false;
            Invoke("EnableJump", jumpcooldown);
        }
    }

    private void EnableJump()
    {
        canJump = true;
    }
    //-------------------------------------------------------------------------------------------

}
