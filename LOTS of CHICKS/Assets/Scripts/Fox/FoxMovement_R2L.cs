// Please read all of my comments :)
using UnityEngine;

public class FoxMovement_R2L : MonoBehaviour
{
    [SerializeField] float xSpeed; // horizontal speed from right to left

    void Start()
    {
        transform.Translate(Vector2.left * (xSpeed * Time.deltaTime)); // moves my fox to left with xSpeed, no matter how fast or slow the computer runs (due to Time.deltaTime)
    }
    private void Update()
    {
        FoxMove();
    }
    void FoxMove()
    {
        transform.Translate(Vector2.left * (xSpeed * Time.deltaTime)); // moves my fox to left with xSpeed, no matter how fast or slow the computer runs (due to Time.deltaTime)
        if (transform.position.x <= -7.80f)
        {
           // xSpeed = -xSpeed; // flips the direction of fox by changing sign
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
}
