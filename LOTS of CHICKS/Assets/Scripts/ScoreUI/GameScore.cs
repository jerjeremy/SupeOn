using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;
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
        Score += 100; // Increases the score by 100 
    }

    public void DecrementScore()
    {
        Score -= 10; // Decrease the score when eggs touch the ground by 10
    }

    public void DecrementScore2()
    {
        Score -= 500; // Decrease the score when picking rotten eggs by 500
    }
}
