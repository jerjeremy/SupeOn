using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] GameObject eggPrefab;

    [SerializeField] private float _minimumSpawnTime;

    [SerializeField] private float _maximumSpawnTime;

    private float _timeUntilSpawn;
    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            Instantiate(eggPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = UnityEngine.Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
