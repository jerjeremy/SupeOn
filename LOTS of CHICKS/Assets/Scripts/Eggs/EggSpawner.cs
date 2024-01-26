using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] GameObject eggPrefab;
    float timerInstantiate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEgg();
    }

    void SpawnEgg()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-4.0f, 5.0f),Random.Range(-1.0f, 4.0f), 0.0f);
        timerInstantiate -= Time.deltaTime;
        if (timerInstantiate <=0)
        {
            Instantiate(eggPrefab, spawnPoint, Quaternion.identity);
            timerInstantiate = 1.0f;
        }
    }
}
