using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBurning : MonoBehaviour
{
    public float timeBetweenBurns;
    public int numberOfWoodBurnedPerTick;
    public GlobalInventory globalInventory;
    public AudioSource fireSound;
    public Light fireLight;
    private bool isLit;

    void Start()
    {
        isLit = false;
        fireLight.enabled = false;
        InvokeRepeating("ConsumeWood", 10f, timeBetweenBurns);
    }

    void ConsumeWood()
    {
        if (globalInventory.wood - numberOfWoodBurnedPerTick < 0)
        {
            Debug.Log("Tried to burn wood, but you don't have enough");
            ExtinguishFire();
        } else
        {
            if (!isLit)
            {
                Debug.Log("Igniting fire");
                LightMyFire();
            }
            globalInventory.DecrementWood(numberOfWoodBurnedPerTick);
        }
    }

    private void LightMyFire()
    {
        isLit = true;
        fireSound.Play();
        fireLight.enabled = true;
    }

    private void ExtinguishFire()
    {
        isLit = false;
        fireSound.Stop();
        fireLight.enabled = false;
    }

    internal bool IsLit()
    {
        return isLit;
    }
}
