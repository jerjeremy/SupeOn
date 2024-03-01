// Please read all of my comments :)
using UnityEngine;

public class FoxMovement_L2R : MonoBehaviour
{
    [SerializeField] float xxSpeed; // horizontal speed from left to right, since xSpeed was already defined
    [SerializeField] float speedIncrement;
    void Start()
    {
        transform.Translate(Vector2.right * (xxSpeed * Time.deltaTime)); // moves my fox to right with xSpeed, no matter how fast or slow the computer runs (due to Time.deltaTime)
    }
    private void Update()
    {
        FoxMove();
        xxSpeed += speedIncrement;
    }
    void FoxMove()
    {
        transform.Translate(Vector2.right * (xxSpeed * Time.deltaTime)); // moves my fox to right with xSpeed, no matter how fast or slow the computer runs (due to Time.deltaTime)
        if (transform.position.x >= 7.20f)
        {
            //xxSpeed = -xxSpeed; // flips the direction of fox by changing sign, doesnt need for now
            Destroy(gameObject);
        }

        //BELOW IS THE RESERVED CODE FOR LATER PART OF THE GAME, IF NEEDED

        //if (transform.position.x >= 7.28f)
        //{
        //    transform.Translate(Vector2.left * -xSpeed * Time.deltaTime); //To stop the fox
        //    Debug.Log(-xSpeed);
        //    Destroy(gameObject); 
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chicken")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
