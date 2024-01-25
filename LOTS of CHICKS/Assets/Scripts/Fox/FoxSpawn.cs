using UnityEngine;

public class FoxSpawn : MonoBehaviour
{
    [SerializeField] private GameObject foxPrefab;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    private float timeUntilSpawn;

    [SerializeField] private Transform[] spawnPositions; // array of spawnPositions

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
        // Choose a random spawn position from the array

        int index = Random.Range(0, 3); // because I have 3 spawn locations at the moment.
        Vector2 randomSpawnPosition = spawnPositions[index].position; //multiple spawners, so can't use transform.positions
        Debug.Log("index: " + index); // developers' use

        Instantiate(foxPrefab, randomSpawnPosition, Quaternion.identity); // it will spawn fox from our specified random position.
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }
}
