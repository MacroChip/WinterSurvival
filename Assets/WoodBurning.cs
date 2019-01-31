using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBurning : MonoBehaviour
{
    public float timeBetweenBurns;
    public int numberOfWoodBurnedPerTick;
    public GlobalInventory globalInventory;

    void Start()
    {
        InvokeRepeating("ConsumeWood", 10f, timeBetweenBurns);
    }

    void ConsumeWood()
    {
        if (globalInventory.wood - numberOfWoodBurnedPerTick < 0)
        {
            Debug.Log("Tried to burn wood, but you don't have enough");
        } else
        {
            globalInventory.DecrementWood(numberOfWoodBurnedPerTick);
        }
    }
}
