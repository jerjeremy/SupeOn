using UnityEngine;

public class FoxMovement : MonoBehaviour
{
    Rigidbody2D rb; // Rigidbody2D component
    [SerializeField] float xSpeed; // horizontal speed
    float xInput; // Horizontal Input

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * xSpeed, rb.velocity.y);
    }
}
