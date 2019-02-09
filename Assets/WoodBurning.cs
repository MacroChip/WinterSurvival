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
    public GameObject wood;

    void Start()
    {
        isLit = false;
        fireLight.enabled = false;
        InvokeRepeating("ConsumeWood", 10f, timeBetweenBurns);
    }

    void ConsumeWood()
    {
        Collider woodInsideStove = GetWoodThatIsInsideStove();
        if (!woodInsideStove)
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
            GameObject.Destroy(woodInsideStove.gameObject);
        }
    }

    private Collider GetWoodThatIsInsideStove()
    {
        BoxCollider stoveCollider = GetComponent<BoxCollider>();
        Vector3 size = stoveCollider.size;
        Collider[] collisions = Physics.OverlapBox(gameObject.transform.position, size / 2);
        foreach (var collider in collisions)
        {
            if (collider.name == wood.name + "(Clone)") {
                return collider;
            }
        }
        return null;
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
