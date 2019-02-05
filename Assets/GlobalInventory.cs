using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public int wood;
    public TMPro.TMP_Text storedWoodText;
    public GameObject woodObject;

    private StoredWoodSpawner StoredWoodSpawner;

    void Awake()
    {
        StoredWoodSpawner = new StoredWoodSpawner(woodObject);
    }

    public void DepositResources(ResourceInventory fromResourceInventory)
    {
        int newWoodCount = fromResourceInventory.GetWood();
        wood += newWoodCount;
        fromResourceInventory.ClearWood();
        UpdateStoredWoodUI();
        Debug.Log("Deposited " + newWoodCount + " wood to the global inventory");
        StoredWoodSpawner.Spawn(newWoodCount);
    }

    internal void DecrementWood(int numberOfWoodBurnedPerTick)
    {
        wood -= numberOfWoodBurnedPerTick;
        UpdateStoredWoodUI();
    }

    private void UpdateStoredWoodUI()
    {
        storedWoodText.SetText(wood + " stored wood");
    }
}
