using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public ObstaclePool obstaclePool;

    public Transform spawnBarrier;
    public Transform despawnBarrier;
    public Transform despawnNet;
    public float obstacleSpeed = 8f;

    [SerializeField] private Transform SpawnTarget;

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", 0f, 4f);
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

            //Rigidbody and speed------------------------------------
            Rigidbody obstacleRigidbody = obstacle.GetComponent<Rigidbody>();

            obstacleRigidbody.velocity = SpawnTarget.forward * obstacleSpeed;

            //Spawn animation-----------------
            StartCoroutine(ScaleUp(obstacle.transform));
        }
    }

    private IEnumerator ScaleUp (Transform obstacleTransform)
    {
        float animationDuration = 0.5f;
        Vector3 targetScale = obstacleTransform.localScale;

        float passedTime = 0f;

        while (passedTime < animationDuration)
        {
            float scaleProgress = passedTime / animationDuration;
            obstacleTransform.localScale = Vector3.Lerp(Vector3.zero, targetScale, scaleProgress);
            passedTime += Time.deltaTime;
            yield return null;
        }

        obstacleTransform.localScale = targetScale;
    }

}
