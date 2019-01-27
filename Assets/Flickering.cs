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
        gameObject.SetActive(!gameObject.active);
        Invoke("ChangeState", Random.Range(1, 3));
    }
}
