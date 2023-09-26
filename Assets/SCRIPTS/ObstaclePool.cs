using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs = new List<GameObject>();
    public int poolSize = 11;

    private List<GameObject> Obstacles;

    private void Start()
    {
        Obstacles = new List<GameObject>();
        StartPool();
    }

    private void StartPool()
    {
        foreach (var prefab in obstaclePrefabs)
        {
            List<GameObject> obstaclePool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obstacle = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                obstacle.SetActive(false);
                obstaclePool.Add(obstacle);
            }

            Obstacles.AddRange(obstaclePool);
        }
    }

    public GameObject GetObstacle()
    {
        foreach (var OBSTACLE in Obstacles)
        {
            if (!OBSTACLE.activeInHierarchy)
            {
                OBSTACLE.SetActive(true);

                OBSTACLE.transform.position = Vector3.zero;
                OBSTACLE.transform.rotation = Quaternion.identity;

                return OBSTACLE;
            }

        }
        return null;
    }
}
