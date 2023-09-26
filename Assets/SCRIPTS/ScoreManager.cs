using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    private int score;

    private void Start()
    {
        score = 0;
        //UpdateScoreText();
    }

    //Score increase----------------------------------
    public void IncreaseScore(int points)
    {
        score += points;
        //UpdateScoreText();
    }
    //------------------------------------------------

    //Fix Needed 
    //private void UpdateScoreText()
    //{
    //    ScoreText.text = "Score:" + score.ToString();
    //}
}
