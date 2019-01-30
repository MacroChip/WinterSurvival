using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHunger : MonoBehaviour
{
    private const int STARTING_FULLNESS = 100;
    public int fullness;
    public int hungerPerTime;
    public Slider hungerGauge;

    void Start()
    {
        fullness = STARTING_FULLNESS;
        InvokeRepeating("ChangeHunger", 10, 10);
    }

    void Update()
    {
        
    }

    void ChangeHunger()
    {
        fullness -= hungerPerTime;
        hungerGauge.value = fullness;
        if (fullness <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You died of hunger");
    }
}
