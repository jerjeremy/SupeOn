using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI; // Assigned to ScoreText 
    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    void Start()
    {
        scoreTextUI = GetComponent<Text>();
        Score = 0;
    }

    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000000}", score);
        scoreTextUI.text = scoreStr;
    }

    public void IncrementScore()
    {
        Score++; // Increases the score by 1
    }
}
