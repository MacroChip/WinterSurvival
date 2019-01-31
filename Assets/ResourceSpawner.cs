using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject resourceToSpawn;
    public float spawnRate;
    public int initialSpawnedCount;
    public int maximumNumberOfResourcesInTheWorldAtOnce;

    private TerrainData terrainData;
    private int numberOfResourcesInWorld;

    void Start()
    {
        GameObject terrainObject = GameObject.Find("Terrain");
        terrainData = terrainObject.GetComponent<Terrain>().terrainData;
        for (int i = 0; i < initialSpawnedCount; i++)
        {
            SpawnResource();
        }
        InvokeRepeating("SpawnResource", 0f, spawnRate);
    }

    void SpawnResource()
    {
        if (numberOfResourcesInWorld < maximumNumberOfResourcesInTheWorldAtOnce)
        {
            Vector3 position = new Vector3(Random.Range(0f, terrainData.size.x), 0.1f, Random.Range(0f, terrainData.size.z));
            Debug.Log($"spawning {resourceToSpawn.name} at " + position.ToString());
            Instantiate(resourceToSpawn, position, Quaternion.identity);
            numberOfResourcesInWorld++;
        }
    }
}
