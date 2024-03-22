using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : ControllerMain
{
    private GameScore gameScore;

    // Start is called before the first frame update
    void Start()
    {
        gameScore = FindObjectOfType<GameScore>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            MainManager.Instance.PlaySFX("5");
            gameScore.IncrementScore();  
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Rotten")
        {
            MainManager.Instance.PlaySFX("5");
            gameScore.DecrementScore2();  
            Destroy(collision.gameObject);
        }

    }
}
