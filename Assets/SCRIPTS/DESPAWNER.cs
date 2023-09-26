using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DESPAWNER : MonoBehaviour
{
    private ScoreManager scoreManager;
    private Transform despawnBarrier;
    public void Initilize(Transform barrier)
    {
        despawnBarrier = barrier;
    }

    public void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        if(transform.position.x < despawnBarrier.position.x)
        {
            gameObject.SetActive(false);
            scoreManager.IncreaseScore(1);
        }
    }

}
