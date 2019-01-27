using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSpawner : MonoBehaviour
{
    public GameObject woodToSpawn;
    private TerrainData terrainData;
    public int spawnRate = 30;

    void Start()
    {
        GameObject terrainObject = GameObject.Find("Terrain");
        terrainData = terrainObject.GetComponent<Terrain>().terrainData;
        InvokeRepeating("SpawnWood", 0f, spawnRate);
    }

    void SpawnWood()
    {
        Vector3 position = new Vector3(Random.Range(0f, terrainData.size.x), 0.1f, Random.Range(0f, terrainData.size.z));
        Debug.Log("spawning wood at " + position.ToString());
        Instantiate(woodToSpawn, position, Quaternion.identity);
    }
}
