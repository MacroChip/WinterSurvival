using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour
{

    void Start()
    {
        Invoke("ChangeState", 5);
    }

    private void ChangeState()
    {
        bool newState = !gameObject.active;
        gameObject.SetActive(newState);
        float delay;
        if (newState)
        {
            delay = Random.Range(3, 8);
        } else
        {
            delay = Random.Range(0.1f, 0.4f);
        }
        Invoke("ChangeState", delay);
    }
}
