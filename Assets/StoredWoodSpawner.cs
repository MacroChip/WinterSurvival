using System;
using UnityEngine;

internal class StoredWoodSpawner
{
    private GameObject woodObject;

    public StoredWoodSpawner(GameObject woodObject)
    {
        this.woodObject = woodObject;
    }

    public void Spawn(int newWoodCount)
    {
        for (int i = 0; i < newWoodCount; i++)
        {
            //new Vector3(-0.03798125f, 0.0902818f, -0.02152209f);
            GameObject.Instantiate(woodObject, GameObject.Find("door_up").transform.position, Quaternion.identity);
        }
    }
}