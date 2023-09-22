using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject standardPathPrefab;
    public GameObject[] pathObstaclePrefab;
    public Transform spawnPoint;

    void Start()
    {
        GeneratePath();
    }

    void GeneratePath()
    {
        int randomIndex = Random.Range(0, pathObstaclePrefab.Length);
        GameObject segmentPrefab = pathObstaclePrefab[randomIndex];
        GameObject newSegment = Instantiate(segmentPrefab, spawnPoint.position, spawnPoint.rotation);

        Transform endMark = newSegment.transform.Find("EndPoint");
        Vector3 nextSegmentPosition = endMark.position;

        Instantiate(standardPathPrefab, spawnPoint.position, Quaternion.LookRotation(nextSegmentPosition - spawnPoint.position));

        spawnPoint = endMark;

        Invoke("GeneratePath", 0.01f);
    }

}
