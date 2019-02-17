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
    }

    void ConsumeWood()
    {
        if (globalInventory.wood - numberOfWoodBurnedPerTick < 0)
        {
            Debug.Log("Tried to burn wood, but you don't have enough");
            ExtinguishFire();
        } else
        {
            globalInventory.DecrementWood(numberOfWoodBurnedPerTick);
        }
    }

    public void LightMyFire()
    {
        if (globalInventory.wood - numberOfWoodBurnedPerTick >= 0 && !IsInvoking("ConsumeWood"))
        {
            Debug.Log("Igniting fire");
            isLit = true;
            fireSound.Play();
            fireLight.enabled = true;
            InvokeRepeating("ConsumeWood", timeBetweenBurns, timeBetweenBurns);
        }
    }

    private void ExtinguishFire()
    {
        isLit = false;
        fireSound.Stop();
        fireLight.enabled = false;
        CancelInvoke("ConsumeWood");
    }

    internal bool IsLit()
    {
        return isLit;
    }
}
