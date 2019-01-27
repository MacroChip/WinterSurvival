using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public int wood;

    public void DepositResources(ResourceInventory fromResourceInventory)
    {
        int newWoodCount = fromResourceInventory.GetWood();
        wood += newWoodCount;
        fromResourceInventory.ClearWood();
        Debug.Log("Deposited " + newWoodCount + " wood to the global inventory");
    }
}
