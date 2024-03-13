using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] float eggSpeed;
    [SerializeField] float RandomRotationStrength;
    [SerializeField] float FloatStrength;
    GameScore gameScore;
    void Start()
    {
        gameScore = FindObjectOfType<GameScore>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * FloatStrength);
		 transform.Rotate(RandomRotationStrength,RandomRotationStrength,RandomRotationStrength);
        //transform.Translate(Vector3.down * (eggSpeed * Time.deltaTime));
        if (transform.position.y <= -6.37f)
        {
            gameScore.DecrementScore();
            MainManager.Instance.PlaySFX("1");
            Destroy(gameObject);
        }
    }
}
