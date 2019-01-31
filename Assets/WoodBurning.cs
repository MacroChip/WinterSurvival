using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBurning : MonoBehaviour
{
    public float timeBetweenBurns;
    public int numberOfWoodBurnedPerTick;
    public GlobalInventory globalInventory;
    private bool isLit;

    void Start()
    {
        isLit = true;
        InvokeRepeating("ConsumeWood", 10f, timeBetweenBurns);
    }

    void ConsumeWood()
    {
        if (globalInventory.wood - numberOfWoodBurnedPerTick < 0)
        {
            Debug.Log("Tried to burn wood, but you don't have enough");
            isLit = false;
        } else
        {
            if (!isLit)
            {
                Debug.Log("Igniting fire");
            }
            isLit = true;
            globalInventory.DecrementWood(numberOfWoodBurnedPerTick);
        }
    }

    internal bool IsLit()
    {
        return isLit;
    }
}
