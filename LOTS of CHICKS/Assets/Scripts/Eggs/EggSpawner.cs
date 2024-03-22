using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] GameObject eggPrefab;
    [SerializeField] GameObject rottenEgg; 

    [SerializeField] private float _minimumSpawnTime; 
    [SerializeField] private float _maximumSpawnTime;

    [SerializeField] private float rottenMinTime;
    [SerializeField] private float rottenMaxTime; 

    [SerializeField] private float decreaseMinBy;
    [SerializeField] private float decreaseMaxBy;

    [SerializeField] private float RottenMinDecrease;
    [SerializeField] private float RottenMaxDecrease; 

    private float _timeUntilSpawn;
    private float _timeUntilSpawn2; 
    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
        TimeUntilSpawn2(); 
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        _timeUntilSpawn2 -= Time.deltaTime; 

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
        if (_timeUntilSpawn2 <= 0)
        {
            Instantiate(rottenEgg, transform.position, Quaternion.identity);
            if (rottenMaxTime >= 2f)
            {
                DecreaseMaxSpawn2(RottenMaxDecrease);
            }
            if (rottenMinTime >= 2f)
            {
                DecreaseMinSpawn2(RottenMinDecrease); 
            }
            TimeUntilSpawn2(); 
        }
    }


    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = UnityEngine.Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    private void TimeUntilSpawn2()
    {
        _timeUntilSpawn2 = UnityEngine.Random.Range(rottenMinTime, rottenMaxTime);
    }

    public void DecreaseMaxSpawnTime(float value)
    {
        _maximumSpawnTime -= value;
    }

    public void DecreaseMinSpawnTime(float value)
    {
        _minimumSpawnTime -= value;
    }

    public void DecreaseMaxSpawn2(float value)
    {
        rottenMaxTime -= value;
    }

    public void DecreaseMinSpawn2(float value)
    {
        rottenMinTime -= value; 
    }
}
