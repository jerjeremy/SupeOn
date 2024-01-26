using UnityEngine;

public class FoxMovementLeft2Right : MonoBehaviour
{
    Rigidbody2D rb; // Rigidbody2D component
    [SerializeField] float xxSpeed; // horizontal speed

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        FoxMoveLeft();
    }
    void FoxMoveLeft()
    {
        transform.Translate(Vector2.right * (xxSpeed * Time.deltaTime)); // moves my fox to left with xSpeed, no matter how fast or slow the computer runs (due to Time.deltaTime)
        if (transform.position.x >= 7.28f)
        {
            xxSpeed = -xxSpeed; // flips the direction of fox by changing sign
        }
        if (transform.position.x <= -7.80f)
        {
            transform.Translate(Vector2.right * -xxSpeed * Time.deltaTime); //To stop the fox
            Debug.Log(-xxSpeed);
            Destroy(gameObject);
        }
    }
}
