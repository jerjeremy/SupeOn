using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] float eggSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (eggSpeed * Time.deltaTime));
        if (transform.position.y <= -6.37f)
        {
            Destroy(gameObject);
        }

    }

    



}
