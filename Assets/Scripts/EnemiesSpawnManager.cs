using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesSpawnManager : MonoBehaviour
{
    // Instantiating Fields
    public GameObject[] objectPrefabs;
    public List<GameObject> spawnPoints = new List<GameObject>();

    private float StartDelay = 30;
    private float SpawnInterval = 30;

    public int activeEnemies;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", StartDelay, SpawnInterval);

    }

    // Update is called once per frame
    void Update()
    {

        // Spawn enemy with "S" key, for testing only
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomEnemy();
        }

    }

    void SpawnRandomEnemy() {
        int objectIndex = UnityEngine.Random.Range(0, objectPrefabs.Length);
        Instantiate(objectPrefabs[objectIndex], spawnPoints[SelectSpawnLocation()].transform.position, objectPrefabs[objectIndex].transform.rotation);
        activeEnemies++;
    }

    int SelectSpawnLocation()
    {
        int locationIndex = UnityEngine.Random.Range(0, spawnPoints.Count - 1);
        spawnPoints.RemoveAt(locationIndex);
        return locationIndex;
    }
}
