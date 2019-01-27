using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSnow : MonoBehaviour
{
    private const string cabin = "WoodenCabinFbx";

    public GameObject blizzard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals(cabin))
        {
            blizzard.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals(cabin))
        {
            blizzard.SetActive(true);
        }
    }
}
