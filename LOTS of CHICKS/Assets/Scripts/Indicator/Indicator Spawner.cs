using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorSpawner : MonoBehaviour
{

    [SerializeField] private GameObject indicator; 

    void Start()
    {
        
    }

    
    void Update()
    {

        GameObject.FindWithTag("Spawn") 

    }

    private void SpawnIndicator()
    {
        Instantiate(indicator, transform.position, Quaternion.identity); 
    }

}
