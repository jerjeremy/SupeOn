using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
    [SerializeField] GameObject chickenPrefab;
    [SerializeField] int numOfChickensToSpawn;
    private Vector2 platformTop;
    private Vector2 platformMid;
    private Vector2 platformBtm;
    [SerializeField] GameObject chickenHolderParent;
    // Start is called before the first frame update
    void Start()
    {
        platformTop = GameObject.Find("Rope1").transform.position;
        platformMid = GameObject.Find("Rope2").transform.position;
        platformBtm = GameObject.Find("Rope3").transform.position;
        SpawnChickens();
        
    }

    // Update is called once per frame
    private void SpawnChickens()
    {
        for (int i = 0; i < numOfChickensToSpawn; i++)
        {
            GameObject c1 = Instantiate(chickenPrefab, platformTop, Quaternion.identity);
            platformTop.x = Random.Range(-4.0f, 4.0f);
            c1.transform.SetParent(chickenHolderParent.transform, true);
            GameObject c2 = Instantiate(chickenPrefab, platformMid, Quaternion.identity);
            platformMid.x = Random.Range(-4.0f, 4.0f);
            c2.transform.SetParent(chickenHolderParent.transform, true);
            GameObject c3 = Instantiate(chickenPrefab, platformBtm, Quaternion.identity);
            platformBtm.x = Random.Range(-4.0f, 4.0f);
            c3.transform.SetParent(chickenHolderParent.transform, true);
        }
    }
}
