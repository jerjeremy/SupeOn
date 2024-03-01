using Unity.VisualScripting;
using UnityEngine;

public class FoxSpawn : MonoBehaviour
{
    [SerializeField] private GameObject foxPrefabToRight;
    [SerializeField] private GameObject foxPrefabToLeft;
    [SerializeField] private GameObject indicatorOnRight;
    [SerializeField] private GameObject indicatorOnLeft;
    [SerializeField] private GameObject shotgunObject; // reference via Unity thru gameObject
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private int DeathLag; //When fox dies
    Vector2 randomSpawnPosition;

    private float timeUntilSpawn;
    private bool firstSpawn;
    private Shotgun _shotgun; // accessing Shotgun Script attached to `shotgunObject`

    [SerializeField] private Transform[] spawnPositions; // array of spawnPositions
    private int lastSpawnIndex = -1; // initialized to a number which is different than our chosen locations
    
    void Awake()
    {
        _shotgun = shotgunObject.GetComponent<Shotgun>();
    }
    void Start()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0 && GameObject.FindGameObjectWithTag("Fox") == null)
        {
            SpawnFox();
            SetTimeUntilSpawn();
        }
    }

    
    private void foxHitOrNot()
    {
        if(_shotgun.foxIsHit == true)
        {
            firstSpawn = false;
        }
        else if(_shotgun.foxIsHit == false)
        {
            firstSpawn = true;
          }
    }

    private void SpawnFox()
    {
        int index;
        do
        {
            index = Random.Range(0, spawnPositions.Length); // because I have 3 spawn locations at the moment.

        } while (index == lastSpawnIndex);

        randomSpawnPosition = spawnPositions[index].position; //multiple spawners, so can't use transform.positions
        Debug.Log("index: " + index); // developers' use
        if (index >= 3) // LEFT
        {
            Invoke("SpawnWarningObjectOnLeft", 0f);
            Invoke("SpawnFoxObjectToRight", 1.0f);
        }
        else if (index < 3) // RIGHT
        {
            Invoke("SpawnWarningObjectOnRight", 0f);
            Invoke("SpawnFoxObjectToLeft", 1.0f);
        }
        
        // lag time
        // instantiate fox
         // it will spawn fox from our specified random position.
        _shotgun.foxIsHit = false;
        lastSpawnIndex = index; // we need to update the lastSpawnIndex to current index, after spawning of fox
    }

    private void SetTimeUntilSpawn()
    {
        foxHitOrNot();
        if (firstSpawn == false)
        {
            timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
        }
        else if(firstSpawn == true)
        {
            timeUntilSpawn = Random.Range(minSpawnTime + DeathLag, maxSpawnTime + DeathLag);
        }
    }

    private void SpawnFoxObjectToRight()
    {
        Instantiate(foxPrefabToRight, randomSpawnPosition, Quaternion.identity);
    }
    private void SpawnFoxObjectToLeft()
    {
        Instantiate(foxPrefabToLeft, randomSpawnPosition, Quaternion.identity);
    }

    private void SpawnWarningObjectOnRight()
    {
        GameObject indicatorClone = Instantiate(indicatorOnRight, randomSpawnPosition, Quaternion.identity);
        // destroy
        Destroy(indicatorClone, 0.5f);
    }
    private void SpawnWarningObjectOnLeft()
    {
        GameObject indicatorClone = Instantiate(indicatorOnLeft, randomSpawnPosition, Quaternion.identity);
        // destroy
        Destroy(indicatorClone, 0.5f);
    }
}
