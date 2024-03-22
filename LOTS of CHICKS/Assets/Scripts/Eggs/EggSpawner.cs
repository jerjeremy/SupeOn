using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] GameObject eggPrefab;
    [SerializeField] GameObject rottenEgg;
    [SerializeField] GameObject freezeEgg;
    [SerializeField] GameObject chaosEgg; 

    [SerializeField] private float _minimumSpawnTime; 
    [SerializeField] private float _maximumSpawnTime;

    [SerializeField] private float rottenMinTime;
    [SerializeField] private float rottenMaxTime;

    [SerializeField] private float freezeMinTime;
    [SerializeField] private float freezeMaxTime;

    [SerializeField] private float chaosMinTime;
    [SerializeField] private float chaosMaxTime; 

    [SerializeField] private float decreaseMinBy;
    [SerializeField] private float decreaseMaxBy;

    private float _timeUntilSpawn;
    private float _timeUntilSpawn2; 
    private float _timeUntilSpawn3;
    private float _timeUntilSpawn4;

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
        TimeUntilSpawn2();
        TimeUntilSpawn3();
        TimeUntilSpawn4();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        _timeUntilSpawn2 -= Time.deltaTime;
        _timeUntilSpawn3 -= Time.deltaTime;
        _timeUntilSpawn4 -= Time.deltaTime;

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
                DecreaseMaxSpawn2(decreaseMaxBy);
            }
            if (rottenMinTime >= 2f)
            {
                DecreaseMinSpawn2(decreaseMinBy);
            }
            TimeUntilSpawn2();
        }
        if (_timeUntilSpawn3 <= 0)
        {
            Instantiate(freezeEgg, transform.position, Quaternion.identity);
            if (freezeMaxTime >= 2f)
            {
                DecreaseMaxSpawn3(decreaseMaxBy);
            }
            if (freezeMinTime >= 2f)
            {
                DecreaseMinSpawn3(decreaseMinBy);
            }
            TimeUntilSpawn3(); 
        }
        if (_timeUntilSpawn4 <= 0)
        {
            Instantiate(chaosEgg, transform.position, Quaternion.identity);
            if (chaosMaxTime >= 2f)
            {
                DecreaseMaxSpawn4(decreaseMaxBy); 
            }
            if (chaosMinTime >= 2f) 
            {
                DecreaseMinSpawn4(decreaseMinBy); 
            }
            TimeUntilSpawn4();
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

    private void TimeUntilSpawn3()
    {
        _timeUntilSpawn3 = UnityEngine.Random.Range(freezeMinTime, freezeMaxTime);
    }

    private void TimeUntilSpawn4()
    {
        _timeUntilSpawn4 = UnityEngine.Random.Range(chaosMinTime, chaosMaxTime); 
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

    public void DecreaseMaxSpawn3(float value)
    {
        freezeMaxTime -= value;
    }

    public void DecreaseMinSpawn3(float value)
    {
        freezeMinTime -= value;
    }

    public void DecreaseMaxSpawn4(float value)
    {
        chaosMaxTime -= value;
    }

    public void DecreaseMinSpawn4(float value)
    {
        chaosMinTime -= value; 
    }

}
