using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{
    // Instantiating Fields
    private float StartDelay = 10;
    private float SpawnInterval = 15.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", StartDelay, SpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy() {
        //int ItemIndex = Random.Range(0, )
    }
}
