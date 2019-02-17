using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    private const float FIRE_STARTER_SECONDS_BETWEEN_SHOTS = 2;
    public Transform actionAnimation;

    private float lastFiredTime = -FIRE_STARTER_SECONDS_BETWEEN_SHOTS;
    private ParticleSystem animationParticleSystem;
    private GameObject stove;
    private WoodBurning woodBurning;

    void Start()
    {
        Transform animationObject = Instantiate(actionAnimation, gameObject.transform);
        animationObject.transform.rotation *= Quaternion.Euler(90, 0, 0);
        animationParticleSystem = animationObject.GetComponent<ParticleSystem>();
        stove = GameObject.Find("Stove");
        woodBurning = GameObject.Find("WoodBurning").GetComponent<WoodBurning>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time - lastFiredTime >= FIRE_STARTER_SECONDS_BETWEEN_SHOTS)
        {
            lastFiredTime = Time.time;
            animationParticleSystem.Play();
            GetComponent<AudioSource>().Play();
            if (Vector3.Distance(gameObject.transform.position, stove.transform.position) <= 3)
            {
                woodBurning.LightMyFire();
            }
        }
    }
}
