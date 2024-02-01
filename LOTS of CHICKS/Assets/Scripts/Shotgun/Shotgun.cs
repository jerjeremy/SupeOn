using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public bool foxIsHit = false;

    void Start()
    {
        //_foxSpawn = GetComponent<FoxSpawn>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //converts the mouse position from screen coordinates to world coordinates relative to main camera
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // casts a 2D ray from the mouse position in all directions for collision detection.

            Debug.Log("Shot Fired!"); // for now to check if fired in world space other than fox, it still works... will add sound later

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Fox"))
                {
                    foxIsHit=true;
                    Debug.Log("Fox Hit");
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    //public void DeathTimeLag()
    //{
    //    _foxSpawn.timeUntilSpawn += DeathLag;
    //}
}
