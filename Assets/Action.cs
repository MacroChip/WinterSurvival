using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public Transform actionAnimation;

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Transform animation = Instantiate(actionAnimation, gameObject.transform);
            animation.transform.rotation *= Quaternion.Euler(90, 0, 0);
        }
    }
}
