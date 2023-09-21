using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        ReadyRestart();
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    //Reset obstacle colliders to false............................
    private void ReadyRestart()
    {
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();
        foreach (Obstacles obstacle in obstacles)
        {
            obstacle.ResetCollisionFlag();
        }
    }
    //..............................................................
}
