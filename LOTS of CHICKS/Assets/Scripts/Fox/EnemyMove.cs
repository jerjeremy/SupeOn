using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * (enemySpeed * Time.deltaTime));
        if (transform.position.x <= -6.3f)
        {
            Destroy(gameObject);
        }
    }
}
