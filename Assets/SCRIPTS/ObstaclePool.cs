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
        List<GameObject> availableObstacles = new List<GameObject>();

        foreach (var OBSTACLE in Obstacles)
        {
            if (!OBSTACLE.activeInHierarchy)
            {
                availableObstacles.Add(OBSTACLE);
            }

        }

        if (availableObstacles.Count > 0)
        {
            //random select an obstacle------------------

            int randomIndex = Random.Range(0, availableObstacles.Count);
            GameObject selectedObstacle = availableObstacles[randomIndex];

            //spawn locations-------------------------------------
            selectedObstacle.transform.position = Vector3.zero;
            selectedObstacle.transform.rotation = Quaternion.identity;

            //Activation--------------------------
            selectedObstacle.SetActive(true);
            return selectedObstacle;
        }
        return null;
    }
}
