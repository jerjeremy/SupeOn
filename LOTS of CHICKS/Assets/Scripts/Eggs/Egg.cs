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
        
        //transform.Translate(Vector3.down * (eggSpeed * Time.deltaTime));
        if (gameObject.tag == "Egg") 
        {
            // egg behaviour
        }
        if(gameObject.tag == "Rotten")
        {
            // rotten behaviour
        }
        if (gameObject.tag == "Freeze")
        {
            // freeze behaviour
        }
        if (gameObject.tag == "Chaos")
        {
            // chaos behaviour
        }
        if (gameObject.tag == "Coin")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * FloatStrength);
		    transform.Rotate(RandomRotationStrength,RandomRotationStrength,RandomRotationStrength);
        }
        if (transform.position.y <= -6.37f)
        {
            MainManager.Instance.PlaySFX("1");
            Destroy(gameObject);
        }

    }
}
