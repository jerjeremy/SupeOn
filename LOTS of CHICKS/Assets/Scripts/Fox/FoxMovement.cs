using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    Rigidbody2D rb; // Rigidbody2D component
    [SerializeField] float xSpeed; // horizontal speed

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            xSpeed = -xSpeed; // flips the direction of fox by changing sign
        }
        if (transform.position.x >= 7.28f)
        {
            transform.Translate(Vector2.left * -xSpeed * Time.deltaTime); //To stop the fox
            Debug.Log(-xSpeed);
            Destroy(gameObject);
            
        }
    }
}
