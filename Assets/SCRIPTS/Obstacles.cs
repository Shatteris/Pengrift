using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    //private bool Collision = false;

    //Reset to false with GameManager---------------------------------------------------------
    //public void ResetCollisionFlag()
    //{
    //    Collision = false;
    //}
    //---------------------------------------------------------------------------------------

    //Collision with Player---------------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            GameOver();
        }
    }
    //-----------------------------------------------------
    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
