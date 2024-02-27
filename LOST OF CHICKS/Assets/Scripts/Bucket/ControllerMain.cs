using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMain : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        float x_input = Input.GetAxis("Horizontal");
        //float y_input = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(x_input, 0f, 0f) * moveSpeed * Time.deltaTime);
    }
}
