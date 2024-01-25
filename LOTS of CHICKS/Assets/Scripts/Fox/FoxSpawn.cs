// Fox Spawner
using UnityEngine;

public class FoxSpawn : MonoBehaviour
{
    [SerializeField] private GameObject foxPrefab;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    private float timeUntilSpawn;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0 && GameObject.FindWithTag("Fox") == null)
        {
            SpawnFox();
            SetTimeUntilSpawn();
        }
    }

    private void SpawnFox()
    {
        Instantiate(foxPrefab, transform.position, Quaternion.identity);
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
