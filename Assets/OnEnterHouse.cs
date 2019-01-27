using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterHouse : MonoBehaviour
{
    private const string cabin = "WoodenCabinFbx";

    public GameObject blizzard;
    public bool isInHouse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals(cabin))
        {
            isInHouse = true;
            blizzard.SetActive(false);
            gameObject.GetComponent<GlobalInventory>().DepositResources(gameObject.GetComponent<ResourceInventory>());

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals(cabin))
        {
            isInHouse = false;
            blizzard.SetActive(true);
        }
    }

    public bool IsInHouse()
    {
        return isInHouse;
    }
}
