using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void OnTriggerEnter(Collider HitBox)
    {
        if(!Collision && HitBox.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Collision = true;
        }
    }
    //-----------------------------------------------------
}
