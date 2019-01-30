using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWoodToInventory : MonoBehaviour
{
    public GameObject wood;

    private void OnTriggerEnter(Collider other)
    {
        Transform parent = other.gameObject.transform.parent;
        if (parent)
        {
            GameObject realWood = parent.gameObject;
            Debug.Log(realWood.name);
            if (realWood.name == (wood.name + "(Clone)"))
            {
                Debug.Log("character gathered wood");
                GetComponent<ResourceInventory>().IncrementWood();
                Destroy(realWood);
            }
        }
    }
}
