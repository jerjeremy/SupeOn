// Fox Spawner
using UnityEngine;

public class FoxSpawn : MonoBehaviour
{
    [SerializeField] private GameObject foxPrefab;
    [SerializeField] private float minSpawnTime; // minimum is needed, at least
    [SerializeField] private float maxSpawnTime; // maximum, because we want to spawn fox between that time interval
    private float timeUntilSpawn;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0 && GameObject.FindWithTag("Fox") == null) //if there is no active fox, instantiate fox then and only.
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
