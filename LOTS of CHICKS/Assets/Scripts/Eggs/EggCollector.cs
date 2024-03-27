using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollector : MonoBehaviour
{
    GameScore gameScore;
    void Start()
    {
        gameScore = FindObjectOfType<GameScore>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            MainManager.Instance.PlaySFX("1");
            Destroy(collision.gameObject);
        }
    }
}
