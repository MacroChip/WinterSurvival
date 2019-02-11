using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItem : MonoBehaviour
{
    public Transform startingItem;

    void Start()
    {
        Transform startingItemHeld = Instantiate(startingItem, Camera.main.transform.position - new Vector3(0, 0.186f, 1.049f), Quaternion.Euler(90, 20, 0), Camera.main.transform);
        startingItemHeld.localScale = new Vector3(3, 3, 3);
    }
}
