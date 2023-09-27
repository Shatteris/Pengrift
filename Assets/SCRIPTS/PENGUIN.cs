using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PENGUIN : MonoBehaviour
{
    public float jumpforce = 10f;
    public float jumpThreshold = 3f;
    public float jumpcooldown = 1f;
    public float acceleration = 10;
    public float lastzpos;
    public LayerMask groundLayer;
    public float maxX, minX;

    private bool canJump = true;
    public bool isGrounded = true;
    private Rigidbody playerBody;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Input.gyro.enabled = true;
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

        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, .5f, 0), .2f, groundLayer);
        Move();
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
        Vector3 MoveInput = new Vector3(directionInput, 0, 0);
        playerBody.AddForce(MoveInput * acceleration);
    }

    //Jump--------------------------------------------------------------------------------------
    private bool Grounded()
    {
        float rayLength = 0.01f;
        Vector3 rayOrigin = transform.position + Vector3.down * 0.1f;

        if (Physics.Raycast(rayOrigin, Vector3.down, rayLength))
        {
            return true;
        }
        else { return false; }
    }


    private void Jump()
    {
        float jumpInput = Input.acceleration.z;
        Debug.Log("JumpInput: " + jumpInput);

        if (jumpInput > lastzpos && Mathf.Abs(jumpInput-lastzpos) >= 0.5f && isGrounded) //&& canJump)
        {
            //canJump = true;
            playerBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            Debug.Log("Jump");
            isGrounded = false;
        }
        Debug.Log("lastzpos: " + lastzpos);
        lastzpos = Input.acceleration.z;
    }

    private void EnableJump()
    {
        canJump = true;
    }
    //-------------------------------------------------------------------------------------------
    private void OnDrawGizmosSelected()
    {
        // Set the gizmo color to red
        Gizmos.color = Color.red;

        // Calculate the position of the sphere cast
        Vector3 sphereCenter = transform.position - new Vector3(0, .5f, 0);

        // Draw the sphere cast gizmo
        Gizmos.DrawWireSphere(sphereCenter, 0.2f);
    }
}
