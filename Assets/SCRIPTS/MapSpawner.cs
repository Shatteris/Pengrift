using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{

    public GameObject[] pathSegmentPrefabs;
    public Transform spawnPoint;

    void Start()
    {
        GeneratePath();
    }


    void Update()
    {
        
    }


    private void GeneratePath()
    {
        int randomIndex = Random.Range(0, pathSegmentPrefabs.Length);
        GameObject segmentPrefab = pathSegmentPrefabs[randomIndex];

        GameObject newSegment = Instantiate(segmentPrefab, spawnPoint.position, spawnPoint.rotation);

        spawnPoint = newSegment.transform.Find("EndPoint");

        float delay = 0.1f;

        Invoke("GeneratePath", delay);
    }

}
