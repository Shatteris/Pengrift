using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PENGUIN : MonoBehaviour
{

    public float tiltSpeed = 5f;
    public float maxtiltAngle = 28f;
    public float speed = 10f;
    public float jumpforce = 10f;
    public float jumpThreshold = 3f;
    public float jumpcooldown = 1f;

    private bool canJump = true;
    private bool isGrounded = true;
    private Rigidbody playerBody;   

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Move();

        isGrounded = Grounded();

        LaneSwitch();

        DetectJump();
    }

    //Move-------------------------------------------------------------
    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);


    }
    //-----------------------------------------------------------------

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

    private void DetectJump()
    {
        if (SystemInfo.supportsGyroscope && isGrounded && canJump)
        {
            Gyroscope gyro = Input.gyro;
            float currentYRotation = gyro.rotationRateUnbiased.y;

                if ( currentYRotation > jumpThreshold)
                {
                    Jump();
                }
        }
    }

        private void Jump()
        {
            playerBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isGrounded = false;
            canJump = false;
            Invoke("EnableJump", jumpcooldown);
        }

        private void EnableJump()
    {
        canJump = true;
    }
    //-------------------------------------------------------------------------------------------



    //Switch Lane--------------------------------------------------------------------------------------------
    private void LaneSwitch()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Gyroscope gyro = Input.gyro;
            Vector3 gyroRotationRate = gyro.rotationRate;

            float targetTiltAngle = Mathf.Clamp(gyroRotationRate.x, -maxtiltAngle, maxtiltAngle);

            Vector3 CurrentAngle = transform.eulerAngles;

            CurrentAngle.x = Mathf.LerpAngle(CurrentAngle.x, targetTiltAngle, tiltSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Euler(CurrentAngle);
        }
    }
    //---------------------------------------------------------------------------------------------------------


    
}
