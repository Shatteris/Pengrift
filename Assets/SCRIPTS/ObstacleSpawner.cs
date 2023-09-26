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
        int randomObstacle = Random.Range(0, obstaclePool.obstaclePrefabs.Count);

        GameObject obstacle = obstaclePool.GetObstacle();

        if ( obstacle != null)
        {
            //Ontop the Ramp----
            obstacle.transform.position = SpawnTarget.position;

            //Rotation----
            obstacle.transform.rotation = Quaternion.Euler(15f, 0f, 0f);

            // Rigidbody--------
            Rigidbody obstacleRigidbody = obstacle.GetComponent<Rigidbody>();

            // Ramp climb velocity--------
            obstacleRigidbody.velocity = transform.forward * obstacleSpeed;

            Collider obstacleCollider = obstacle.GetComponent<Collider>();
            if ( obstacleCollider != null)
            {
                obstacleCollider.enabled = true;
            }
        }
    }

}
