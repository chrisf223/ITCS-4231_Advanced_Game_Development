    using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using cakeslice;

public class EnemiesSpawnManager : MonoBehaviour
{
    // Instantiating Fields
    public GameObject[] objectPrefabs;
    public List<GameObject> spawnPoints = new List<GameObject>();

    private float StartDelay = 30;
    private float SpawnInterval = 30;

    private float BoxScaleX = 0.5f;
    private float BoxScaleY = 0.5f;
    private float BoxScaleZ = 0.5f;
    private float BoxCenterY = 0.1f;

    public int activeEnemies;

    public GUIManager gui;

    //private bool Hasbul = GUIManager.IsRepoOn;

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
        AddLayer(objectPrefabs, objectIndex);
        AddScriptSettings(objectPrefabs, objectIndex);
        activeEnemies++;
    }

    int SelectSpawnLocation()
    {
        int locationIndex = UnityEngine.Random.Range(0, spawnPoints.Count - 1);
        spawnPoints.RemoveAt(locationIndex);
        return locationIndex;
    }

    // Adds a box collider to game object.
    void AddBoxCollider(GameObject[] x, int objIndex) {
        // Checks to see if box collider already there.
        if (x[objIndex].GetComponent<BoxCollider>() != null) {
            Debug.Log(x[objIndex] + " : Yes, I have a box collider!");
        } else {
            x[objIndex].AddComponent<BoxCollider>();
            x[objIndex].GetComponent<BoxCollider>().size = new Vector3 (BoxScaleX, BoxScaleY, BoxScaleZ);
            x[objIndex].GetComponent<BoxCollider>().center = new Vector3 (0, BoxCenterY, 0);
        }
    }

    // Adds a mesh renderer to game object.
    void AddMeshRenderer(GameObject[] x, int objIndex) {
        // Checks to see if it already has a mesh
        if (x[objIndex].GetComponent<MeshRenderer>() != null) {
            Debug.Log(x[objIndex] + " : Yes, I have a mesh!");
        } else
            x[objIndex].AddComponent<MeshRenderer>();
    }
    
    // Adds the nesessary scripts onto the game object.
    void AddScriptSettings(GameObject[] x, int objIndex) {
        // Adds the necessary subcomponents to the scripts.
        //bool IsOn = gui.IsRepoOn;
        //x[objIndex].GetComponent<TargetSelect>().rep = gui;
        x[objIndex].GetComponent<Outline>().eraseRenderer = true;
    }

    // Sets object in a specific layer
    void AddLayer(GameObject[] x, int objIndex) {
        int LayerEnemies = LayerMask.NameToLayer("Enemies");
        x[objIndex].layer = LayerEnemies;
        Debug.Log("Layer: " + LayerEnemies);
    }
}
