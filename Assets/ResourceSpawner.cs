using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject resourceToSpawn;
    private TerrainData terrainData;
    public int spawnRate;

    void Start()
    {
        GameObject terrainObject = GameObject.Find("Terrain");
        terrainData = terrainObject.GetComponent<Terrain>().terrainData;
        InvokeRepeating("SpawnResource", 0f, spawnRate);
    }

    void SpawnResource()
    {
        Vector3 position = new Vector3(Random.Range(0f, terrainData.size.x), 0.1f, Random.Range(0f, terrainData.size.z));
        Debug.Log($"spawning {resourceToSpawn.name} at " + position.ToString());
        Instantiate(resourceToSpawn, position, Quaternion.identity);
    }
}
