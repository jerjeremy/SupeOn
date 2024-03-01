using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] GameObject eggPrefab;

    [SerializeField] private float _minimumSpawnTime;

    [SerializeField] private float _maximumSpawnTime;
    [SerializeField] private float decreaseMinBy;
    [SerializeField] private float decreaseMaxBy;


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
            if (_maximumSpawnTime >= 2f)
            {
                DecreaseMaxSpawnTime(decreaseMaxBy);
            }
            if (_minimumSpawnTime >= 2f)
            {
                DecreaseMinSpawnTime(decreaseMinBy);
            }
            
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = UnityEngine.Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    public void DecreaseMaxSpawnTime(float value)
    {
        _maximumSpawnTime -= value;
    }

    public void DecreaseMinSpawnTime(float value)
    {
        _minimumSpawnTime -= value;
    }


}
