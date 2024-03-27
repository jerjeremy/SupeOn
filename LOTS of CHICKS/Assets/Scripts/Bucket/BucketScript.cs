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
        MainManager.Instance.PlaySFX("5");

        if (collision.gameObject.tag == "Egg")
        {
            gameScore.IncrementScore(100);
        }
        if (collision.gameObject.tag == "Rotten")
        {
            gameScore.DecrementScore(500);  
        }
        if (collision.gameObject.tag == "Freeze")
        {
            // do freeze things
        }
        if (collision.gameObject.tag == "Chaos") 
        {
            // do chaos things
        }
        if (collision.gameObject.tag == "Coin")
        {
            gameScore.IncrementScore(500);
        }
        Destroy(collision.gameObject);
    }
}
