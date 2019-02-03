using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFoodGather : MonoBehaviour
{
    public GameObject food;
    public PlayerHunger playerHunger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == (food.name + "(Clone)"))
        {
            Debug.Log($"character gathered {food.name}");
            playerHunger.Feed(10);
            Destroy(other.gameObject);
        }
    }
}
