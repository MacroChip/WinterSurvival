using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public GameObject woodObject;

    private StoredWoodSpawner StoredWoodSpawner;

    void Awake()
    {
        StoredWoodSpawner = new StoredWoodSpawner(woodObject);
    }

    public void DepositResources(ResourceInventory fromResourceInventory)
    {
        int newWoodCount = fromResourceInventory.GetWood();
        fromResourceInventory.ClearWood();
        Debug.Log("Deposited " + newWoodCount + " wood to the global inventory");
        StoredWoodSpawner.Spawn(newWoodCount);
    }
}
