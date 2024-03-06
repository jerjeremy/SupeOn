using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    //issues: Eggs collide into each other and no idea what time we need for each special egg spawn

    [SerializeField] GameObject eggPrefab;
    [SerializeField] GameObject chaosPrefab;
    [SerializeField] GameObject freezePrefab;
    [SerializeField] GameObject rottenPrefab; 

    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _chaosMinSpawnTime;
    [SerializeField] private float _freezeMinSpawnTime;
    [SerializeField] private float _rottenMinSpawnTime;

    [SerializeField] private float _maximumSpawnTime;
    [SerializeField] private float _chaosMaxSpawnTime;
    [SerializeField] private float _freezeMaxSpawnTime;
    [SerializeField] private float _rottenMaxSpawnTime; 

    private float _timeUntilSpawn;
    private float _timeChaosSpawn;
    private float _timeFreezeSpawn;
    private float _timeRottenSpawn; 

    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
        ChaosSpawn();
        FreezeSpawn();
        RottenSpawn(); 
      
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        _timeChaosSpawn -= Time.deltaTime;
        _timeFreezeSpawn -= Time.deltaTime;
        _timeRottenSpawn -= Time.deltaTime; 

        if (_timeUntilSpawn <= 0)
        {
            Instantiate(eggPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
        if (_timeChaosSpawn <= 0)
        {
            Instantiate(chaosPrefab, transform.position, Quaternion.identity);
            ChaosSpawn(); 
        }
        if (_timeFreezeSpawn <= 0)
        {
            Instantiate(freezePrefab, transform.position, Quaternion.identity);
            FreezeSpawn();
        }
        if (_timeRottenSpawn <= 0) 
        {
            Instantiate(rottenPrefab, transform.position, Quaternion.identity);
            RottenSpawn(); 
        }

    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = UnityEngine.Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    private void ChaosSpawn()
    {
        _timeChaosSpawn = UnityEngine.Random.Range(_chaosMinSpawnTime, _chaosMaxSpawnTime); 
    }

    private void FreezeSpawn()
    {
        _timeFreezeSpawn = UnityEngine.Random.Range(_freezeMinSpawnTime, _freezeMaxSpawnTime);
    }

    private void RottenSpawn()
    {
        _timeRottenSpawn = UnityEngine.Random.Range(_rottenMinSpawnTime, _rottenMaxSpawnTime); 
    }
}
