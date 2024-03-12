using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] float eggSpeed;
    GameScore gameScore;
    void Start()
    {
        gameScore = FindObjectOfType<GameScore>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (eggSpeed * Time.deltaTime));
        if (transform.position.y <= -6.37f)
        {
            gameScore.DecrementScore();
            MainManager.Instance.PlaySFX("1");
            Destroy(gameObject);
        }
    }
}
