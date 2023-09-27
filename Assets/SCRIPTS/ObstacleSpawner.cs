using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public ObstaclePool obstaclePool;

    public Transform spawnBarrier;
    public Transform despawnBarrier;
    public float obstacleSpeed = 3f;

    [SerializeField] private Transform SpawnTarget;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, 3f);
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = obstaclePool.GetObstacle();

        if(obstacle!= null)
        {
            //On top of ramp----------------
            obstacle.transform.position = SpawnTarget.position;

            //Rotation--------------------------------------------
            obstacle.transform.rotation = Quaternion.Euler(0f, -90f, 0f);

            //Rigidbody and speed going up the ramp------------------------------------
            Rigidbody obstacleRigidbody = obstacle.GetComponent<Rigidbody>();

            obstacleRigidbody.velocity = SpawnTarget.forward * obstacleSpeed;
        }
    }

}
