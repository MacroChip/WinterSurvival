using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWoodToInventory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other is CharacterController)
        {
            Debug.Log("character gathered wood");
            other.GetComponent<ResourceInventory>().IncrementWood();
            Destroy(gameObject);
        }
    }
}
