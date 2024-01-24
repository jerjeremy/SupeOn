using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
   // [SerializeField] GameObject Explosion;
   
    private float Spawnrate = 1.25f;
    private float timer = 1.5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < Spawnrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            timer = 0f;
        }
        
    }
    void spawnEnemy()
    {
        Instantiate(EnemyPrefab, new Vector3(7.6f, Random.Range(-4.0f, 3.5f), 0f), Quaternion.Euler(0f,0f,90f)); // 90 for rotation, it was spawning left
        //Instantiate(EnemyBulletPrefab, new Vector3(7.6f, Random.Range(-4.0f, 3.5f), 0f), Quaternion.Euler(0f, 0f, 0f)); // 90 for rotation, it was spawning left
    }
}
