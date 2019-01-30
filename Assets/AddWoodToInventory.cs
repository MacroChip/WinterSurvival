using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWoodToInventory : MonoBehaviour
{
    public GameObject wood;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == (wood.name + "(Clone)"))
        {
            Debug.Log("character gathered wood");
            GetComponent<ResourceInventory>().IncrementWood();
            Destroy(other.gameObject);
        }
    }
}
