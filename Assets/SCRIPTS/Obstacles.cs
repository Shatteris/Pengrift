using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    private bool Collision = false;

    //Reset to false with GameManager---------------------------------------------------------
    public void ResetCollisionFlag()
    {
        Collision = false;
    }
    //---------------------------------------------------------------------------------------


    //Detect Player----------------------------------------
    private void OnTriggerEnter(Collider HitBox)
    {
        if(!Collision && HitBox.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Collision = true;
            GameOver();
        }
    }
    //-----------------------------------------------------

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
